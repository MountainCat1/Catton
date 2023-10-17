#!/bin/bash

set -e

# Array of service names
serviceNames=('conventions' 'accounts', '')
targetFramework=typescript-angular 

# Set variables
TARGET_DIR="/openapi-${targetFramework}"
ABS_TARGET_DIR="$(pwd)$TARGET_DIR"
OUTPUT_FOLDER_NAME="openapi"

# Loop through the service names array
for serviceName in "${serviceNames[@]}"; do
  # Set variable with api specs
  apiSpecsDir="https://localhost:5000/swagger/docs/v1/${serviceName}"
  SPECS_TARGET_DIR="$TARGET_DIR/${serviceName}/api-spec.json"

  # Create the directory for the current service
  mkdir -p "$ABS_TARGET_DIR/${serviceName}"

  # Download the OpenAPI specification ignoring SSL verification
  curl -k -o ".$SPECS_TARGET_DIR" $apiSpecsDir

  echo "Generating Angular service for '$serviceName'..."

  # Use MSYS_NO_PATHCONV to fix the volume path problem
  MSYS_NO_PATHCONV=1 docker run --rm -v "$ABS_TARGET_DIR/${serviceName}:/local" openapitools/openapi-generator-cli sh -c "ls /local"

  # Run the Docker container to generate the Angular service
  MSYS_NO_PATHCONV=1 docker run --rm -v "$ABS_TARGET_DIR/${serviceName}:/local" openapitools/openapi-generator-cli generate \
    -i /local/api-spec.json \
    -g ${targetFramework} \
    -o /local/${OUTPUT_FOLDER_NAME}

  echo 
  mv .${TARGET_DIR}/${serviceName}/${OUTPUT_FOLDER_NAME}/* .${TARGET_DIR}/${serviceName}/

  echo "Angular service generated successfully for '$serviceName'."
done

echo "All Angular services generated successfully in '$ABS_TARGET_DIR' directory."
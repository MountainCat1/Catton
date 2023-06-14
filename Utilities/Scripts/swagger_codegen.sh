#!/bin/bash

set -e

# Array of service names
serviceNames=('convention' 'account' )

# Set variables
TARGET_DIR="/openapi-generated"
ABS_TARGET_DIR="$(pwd)$TARGET_DIR"
OUTPUT_FOLDER_NAME="openapi-generated"

# Loop through the service names array
for serviceName in "${serviceNames[@]}"
do
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
    -g typescript-angular \
    -o /local/${OUTPUT_FOLDER_NAME}

  echo "Angular service generated successfully for '$serviceName'."
done

echo "All Angular services generated successfully in '$ABS_TARGET_DIR' directory."

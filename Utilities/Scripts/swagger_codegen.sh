#!/bin/bash

set -e

# Set variable with api specs
apiSpecsDir="https://localhost:5000/swagger/docs/v1/account"

# Set variables
TARGET_DIR="/generated-api"
ABS_TARGET_DIR="$(pwd)$TARGET_DIR"
SPECS_TARGET_DIR="$TARGET_DIR/api-spec.json"

OUTPUT_FOLDER_NAME="openapi-generated"

# Create the gen directory if it doesn't exist
mkdir -p "$ABS_TARGET_DIR"

# Download the OpenAPI specification ignoring SSL verification
curl -k -o ".$SPECS_TARGET_DIR" $apiSpecsDir

echo "$ABS_TARGET_DIR"

# Use MSYS_NO_PATHCONV to fix the volume path problem
MSYS_NO_PATHCONV=1 docker run --rm -v "$ABS_TARGET_DIR:/local" openapitools/openapi-generator-cli sh -c "ls /local"

# Run the Docker container to generate the Angular service
MSYS_NO_PATHCONV=1 docker run --rm -v "$ABS_TARGET_DIR:/local" openapitools/openapi-generator-cli generate \
  -i /local/api-spec.json \
  -g typescript-angular \
  -o /local/${OUTPUT_FOLDER_NAME}

echo "Angular service generated successfully in '$ABS_TARGET_DIR' directory."

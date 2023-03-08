#!/bin/bash

# Define variables
container_name="guid-generator-redis"
remove_existing_container=0

# Define environment variables for Redis container
export REDIS_PASSWORD
export REDIS_PORT

REDIS_PASSWORD=$(cat "$(dirname "$0")/Secrets/database-password-secret")
REDIS_PORT=6379


# Check for command-line arguments
while [[ $# -gt 0 ]]; do
  case "$1" in
  -r)
    remove_existing_container=1
    shift
    ;;
  --port=*)
    REDIS_PORT=${1#*=} # remove prefix "--port="
    shift
    ;;
  --name=*)
    container_name="${1#*=}" # remove prefix "--name="
    shift
    ;;
  -*)
    echo "Invalid option: $1" >&2
    exit 1
    ;;
  esac
done

# Check if container already exists
if [ "$(docker ps -q -f name="$container_name")" ] && [ "$remove_existing_container" -eq 0 ]; then
  echo "Error: Redis container already exists. Use the -r option to remove the existing container before starting a new one." >&2
  exit 1
elif [ "$remove_existing_container" -eq 0 ]; then
  echo "Container $container_name doesn't exist"
fi

# Remove existing container if requested
if [ $remove_existing_container -eq 1 ] && [ "$(docker ps -aq -f name="$container_name")" ]; then
  echo "Removing existing Redis container..."
  docker stop "$container_name" >/dev/null
  docker rm "$container_name" >/dev/null
fi

# Start Redis container
echo "Creating container $container_name..."
docker run --name "$container_name" -p "$REDIS_PORT":6379 -e REDIS_PASSWORD -d redis

# Verify container is running
if [ "$(docker ps -q -f name="$container_name")" ]; then
  echo "Redis container is running with name $container_name"
else
  echo "Redis container failed to start"
fi

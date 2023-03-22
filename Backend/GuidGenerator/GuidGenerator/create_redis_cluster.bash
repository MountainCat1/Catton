#!/bin/bash

# Define variables
container_name="redis-cluster"
remove_existing_container=1
node_count=3

# Define environment variables for Redis container
export REDIS_PASSWORD
export REDIS_PORT

REDIS_PASSWORD=$(cat "$(dirname "$0")/Secrets/database-password-secret")
REDIS_PORT=6379



# Remove existing container if requested
if [ $remove_existing_container -eq 1 ] && [ "$(docker ps -aq -f name="$container_name")" ]; then
  echo "Removing existing Redis container..."
  docker stop "$container_name" >/dev/null
  docker rm "$container_name" >/dev/null
fi

docker run --name "$container_name" \
 -p 5555:6379 \
 -d \
 -e REDIS_NODES=$node_count \
 -e ALLOW_EMPTY_PASSWORD=yes \
 bitnami/redis-cluster:latest 
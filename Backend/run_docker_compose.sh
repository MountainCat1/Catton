#bin/bash

# Build docker compose without cache
docker compose build --no-cache

# Stop and remove existing containers
docker-compose down

# Build and start the containers
docker-compose up -d

# Display container status
docker-compose ps
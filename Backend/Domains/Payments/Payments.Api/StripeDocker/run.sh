#!/bin/bash

port="4000"
container_name="stripe"

#docker stop stripe
#docker rm stripe

echo "Starting stripe-cli container..."

image="stripe/stripe-cli:latest"
webhook_url="http://host.docker.internal:$port/api/webhooks/stripe"

docker run --name $container_name -it $image listen --forward-to $webhook_url

docker start $container_name
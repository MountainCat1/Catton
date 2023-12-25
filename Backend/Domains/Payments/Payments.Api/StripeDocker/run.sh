#!/bin/bash -x

port="4021"

docker stop stripe
#docker rm stripe

echo "Starting stripe-cli container..."

#docker run --name stripe -it stripe/stripe-cli:latest listen --forward-to http://host.docker.internal:$port/api/webhook

docker start stripe
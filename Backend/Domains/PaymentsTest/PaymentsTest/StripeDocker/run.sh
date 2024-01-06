
docker run --name stripe -it stripe/stripe-cli:latest listen --forward-to host.docker.internal:4242/webhook
docker start stripe
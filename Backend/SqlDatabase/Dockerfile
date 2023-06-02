# Base image
FROM mcr.microsoft.com/mssql/server:2017-latest

# Set environment variables
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Password123!
ENV CONTAINER_NAME=sql_server

# Install dependencies
USER root
RUN apt-get update && apt-get install -y \
    curl \
    && rm -rf /var/lib/apt/lists/*

# Create a config directory
RUN mkdir -p /usr/config
WORKDIR /usr/config

# Bundle config source
COPY . /usr/config

# Grant permissions for our scripts to be executable
RUN chmod +x /usr/config/entrypoint.sh
RUN chmod +x /usr/config/configure-db.sh

ENTRYPOINT ["/bin/bash", "./entrypoint.sh"]

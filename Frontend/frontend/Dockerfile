# Use an official Node.js v18.15.0 runtime as the base image
FROM node:18.15.0 as builder

# Set the working directory inside the container
WORKDIR /app

# Copy package.json and package-lock.json to the working directory
COPY package*.json ./

# Install the dependencies
RUN npm install

# Copy the entire application code to the working directory
COPY . .

# Build the Angular app for production using the "dockerswarm" environment
RUN npm run build -- --configuration=dockerswarm

# Use a lightweight NGINX image as the base image for serving the static files
FROM nginx:1.21

# Copy the built Angular app from the previous stage to the NGINX document root
COPY --from=builder /app/dist/frontend /usr/share/nginx/html

# Expose port 80 to the outside world
EXPOSE 80

# Start NGINX when the container starts
CMD ["nginx", "-g", "daemon off;"]

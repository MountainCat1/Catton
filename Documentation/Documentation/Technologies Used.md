# DevOps

### Hosting
- Catton is hosted on Azure.
- Catton uses Azure App Service to host all of its services.
- Catton uses Azure Blob Storage to store configuration
- Catton uses Azure Key Vault to store secrets
- Catton uses Azure SQL Database to store data

### Docker
- Catton uses Docker to containerize all of its services. This allows for easy deployment and scaling of the application.
- All projects contain two Dockerfiles one for local deployment called `Dockerfile` and one for deployment on Azure called `Azure.Dockerfile`

### Local Deployment
- To deploy locally `./run_docker_compose.sh` can be used to run all services locally.
- To run local deployment Docker needs to be installed with support for docker-compose v2.

### Pipelines
- Catton uses Azure DevOps Pipelines to deploy to Azure.
- Each service has its own pipeline that is triggered on push to `main` branch.
- All pipelines are located in `Catton\pipelines`

# Utilities

### Catton Initializer
- Catton Initializer is a console application that is used to initialize the database with initial data.
- Catton Initializer is located in `Catton\Utilities\Initializer`
- Catton Initializer uses HTTP requests to initialize the environment with
  - Admin account
  - Multiple Dummy account
  - One convention
  - Attendees relationships
  - Ticket Templates

### KeyGenerator
- KeyGenerator is a console application that is used to generate keys for JWT tokens.
- KeyGenerator is located in `Catton\Utilities\KeyGenerator`
- KeyGenerator uses RSA algorithm to generate keys.
- KeyGenerator generates two keys one for signing and one for validation of JWT tokens.
- KeyGenerator generates `.json` file that contains necessary config compatible with Catut package.

### Api Client Generator
- Set of bash scripts that are used to generate API clients for Catton services.
- Api Client Generator is located in `Catton\Utilities\ApiClientGenerator`
- Api Client Generator uses `NSwag` to generate API clients.
- Api Client generator generates clients using openapitools/openapi-generator-cli docker image.

# Backend
### Domains
- Catton is a microservice-based application, with each service being responsible for a specific domain.
- All domains in Catton are supported by ASP.NET 8.0.
- Catton's domains are:
  - Accounts Domain
  - Payments Domain
  - Conventions Domain

### API Gateway

- We employ the Ocelot NuGet package as our API gateway to efficiently route traffic from a single domain to various backend services.
- API gateway contains configs for running it in IDE environment, Docker environment and Azure environment.

### Database Access

- The Catton application relies on Microsoft's Entity Framework for all database access, ensuring that all requests are processed through this Object-Relational Mapping (ORM) framework.
- Catton uses Code First approach to Entity Framework, where we define our database schema using C# classes and then generate the database from these classes.
- Catton uses Repository pattern to abstract away the database access logic from the rest of the application.
- Catton uses Unit of Work pattern to ensure that all database operations are performed in a single transaction.
- Catton uses Mediator pattern to decouple the business logic from the database access logic.
- Catton uses CQRS pattern to separate the read and write operations on the database.

### API Schema

- Our backend follows a RESTful API schema for modeling its API.
- All API endpoints are documented using Swagger.
- All API endpoints that need authentication use JWT tokens.
- All API endpoints that need authentication use `Authorization` header with `Bearer` token.

### Catut Nuget packages
- Catton uses custom Nuget package that contains common login used across all backend services
- Catut is located in `Catton\Utilities\Catut`
- Catut is divided into three separate packages
	- Catut.Application - contains common application logic
    - Catut.Infrastructure - contains common infrastructure logic
    - Catut.Domain - contains common domain logic
### Third party Nuget packages
- Catton uses multiple third party Nuget packages
- Packages worth mentioning are:
  - MediaTR - used for implementing Mediator pattern
  - FluentValidation - used for validating requests
  - AutoMapper - used for mapping between DTOs and Entities
  - Swashbuckle.AspNetCore - used for generating Swagger documentation
  - Microsoft.EntityFrameworkCore - used for database access
  - Microsoft.AspNetCore.Authentication.JwtBearer - used for authentication
  - Azure.Security.KeyVault.Secrets - used for accessing Azure Key Vault
  - Azure.Storage.Blobs - used for accessing Azure Blob Storage
---

# Frontend

* Catton Frontend is a single page application (SPA) built using Angular.
* Catton Frontend is located in `Catton\Frontend`
* Catton Frontend uses Angular Material for UI components.
* Catton Frontend uses JWT for authentication while communicating with backend services.
* Catton Frontend communicates with backend services through API Gateway.
* Catton Frontend uses `Api Client Generator` to generate API clients for backend services.
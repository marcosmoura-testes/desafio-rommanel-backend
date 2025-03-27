# Client Management API

## Overview
This API is designed to manage client data, providing endpoints to create, read, update, and delete client information. The solution is built using .NET 8 and follows a clean architecture approach combined with CQRS (Command Query Responsibility Segregation) to ensure maintainability and scalability.

## Architecture
The architecture of this solution is based on the following layers:
- **API Layer**: This layer contains the controllers and handles HTTP requests and responses.
- **Application Layer**: This layer contains the business logic, including commands, queries, and handlers.
- **Domain Layer**: This layer contains the core entities and domain logic.
- **Infrastructure Layer**: This layer contains the data access logic and external service integrations.

## Packages
The following NuGet packages are used in this solution:
- `Microsoft.AspNetCore.App`: Provides the ASP.NET Core framework.
- `MongoDB.Driver`: Official MongoDB driver for .NET.
- `AutoMapper`: A library to map objects.
- `FluentValidation`: A library for building strongly-typed validation rules.
- `Swashbuckle.AspNetCore`: A library to generate Swagger documentation.

## Docker Compose
The solution includes a `docker-compose.yml` file to set up the MongoDB database. The configuration is as follows:

## Getting Started
To run the solution locally, follow these steps:
1. Ensure Docker is installed and running on your machine.
2. Clone the repository.
3. Navigate to the project directory.
4. Run `docker-compose up` to start the MongoDB container.
5. Open the solution in Visual Studio.
6. Restore the NuGet packages.
7. Build the solution.
8. Press `F5` to run the project.

## API Endpoints
The following endpoints are available in the API:
- `GET /api/client`: Retrieves a list of clients.
- `GET /api/client/{id}`: Retrieves a specific client by ID.
- `POST /api/client`: Creates a new client.
- `PUT /api/client/{id}`: Updates an existing client.
- `DELETE /api/client/{id}`: Deletes a client.

## Swagger Documentation
Swagger documentation is available at `/` once the API is running. This provides an interactive interface to test the API endpoints.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request with your changes.

## License
This project is licensed under the MIT License.

# Poc.TaskHub

`Poc.TaskHub` is a Proof of Concept (PoC) project designed to demonstrate the implementation of Domain-Driven Design (DDD) and Command Query Responsibility Segregation (CQRS) within the context of a todo list application. This repository serves as a practical reference for software architects, developers, and students interested in exploring how these design patterns can be applied to build robust, scalable, and maintainable applications.

The core of the project, `Poc.TaskHub.Api`, provides a RESTful API for creating, querying, updating, and deleting tasks, showcasing how DDD and CQRS can facilitate a clear separation between business logic and infrastructure operations. Through this API, users can interact with the task management system, which is designed to be intuitive and user-friendly, while also being powerful and flexible enough to accommodate different task management needs.

## Features

- **Domain Modeling**: Uses DDD to model the task management domain, capturing business complexity and promoting a domain-oriented design.
- **Command and Query Separation**: Implements CQRS to separate read and write operations, optimizing application performance and scalability.
- **Validation and Exception Handling**: Features a robust validation system to ensure data integrity and effective exception handling.
- **Infrastructure and Cross-Cutting Concerns**: Offers a well-organized architecture addressing cross-cutting concerns such as logging, security, and configuration.

## Project Structure

The repository is organized into several projects, each focusing on a specific aspect of the Poc.TaskHub application. 
This modular structure promotes separation of concerns, facilitates ease of maintenance, and demonstrates best practices in code organization. Below is an overview of each project and its role within the application:

- **Poc.TaskHub.Api**: The entry point for the application, exposing a RESTful API interface for task management operations.
- **Poc.TaskHub.Business.Commands**: Contains the command handlers responsible for executing write operations, aligned with CQRS principles.
- **Poc.TaskHub.Business.Domain**: Implements the core business logic and domain models, central to the application's functionality.
- **Poc.TaskHub.Business.Queries**: Handles query operations, allowing for the retrieval of data in accordance with CQRS principles.
- **Poc.TaskHub.Business.Validation**: Provides validation logic to ensure data integrity and business rules are enforced before executing commands or queries.
- **Poc.TaskHub.CrossCutting**: Includes cross-cutting concerns such as logging, configuration, and security, supporting the application's non-functional requirements.
- **Poc.TaskHub.Eai**: Stands for Enterprise Application Integration, facilitating communication with external systems and services.
- **Poc.TaskHub.Service**: Implements the service layer, orchestrating the interaction between the API, command handlers, and query handlers.

## Getting Started

To set up the Poc.TaskHub project and get it running on your local development environment, follow these steps:

### Prerequisites

- .NET SDK 8
- Visual Studio 2022

### Installation

1. Clone the repository to your local machine.
2. Open the solution file (`Poc.TaskHub.sln`) in Visual Studio.
3. Restore all NuGet packages by right-clicking on the solution and selecting "Restore NuGet Packages".

### Running the Application

1. Set `Poc.TaskHub.Api` as the startup project in Visual Studio.
2. Run the project using Visual Studio's built-in server (IIS Express or Kestrel). By default, the API will be hosted locally at http://localhost:5022 when using Kestrel.
3. Access the API endpoints through a web browser or a tool like Postman to interact with the application.

This setup will get your local development environment up and running with the Poc.TaskHub application, allowing you to explore and extend the project further.
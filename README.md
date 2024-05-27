# Islands Backend

## Overview

The backend of the Islands project is developed using C#. This README provides an overview of the backend structure and the best practices followed in its construction.

## Project Structure

The backend is organized into the following main directories:

- **Controllers**: Contains the API controllers that handle HTTP requests and responses.
- **Application**: Defines the data models and business rules used throughout the application.
- **Repositories**: Handles data access.

## Best Practices

### 1. **Separation of Concerns**
Each layer (Controller, Application, Repository) has a distinct responsibility, promoting a clean architecture and making the code easier to maintain and test.

### 2. **Dependency Injection**
Dependency Injection (DI) is used extensively to manage dependencies, which enhances modularity and testability.

### 3. **Exception Handling**
Centralized exception handling ensures that all exceptions are logged appropriately and meaningful error messages are returned to the client.

### 4. **Automated Testing**
Unit tests are created for critical components to ensure the correctness of the application. Tests are placed in a dedicated test project.

## Getting Started

### Prerequisites
- .NET SDK 8.0

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/reasilvabr/islands.git
2. Navigate to the backend directory:
   ```sh
   cd islands/backend
3. Restore dependencies:
   ```sh
   dotnet restore
4. Running the Application
   ```sh
   dotnet run
5. Running Tests   
   ```sh
   dotnet test
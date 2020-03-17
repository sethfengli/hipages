# Setup Development Environment

### Download and install Docker for Windows 10

    https://hub.docker.com/editions/community/docker-ce-desktop-windows


### Download and install MySQL Workbench

    https://dev.mysql.com/downloads/workbench/

### Download VS Code for the front-end development

    https://code.visualstudio.com/download

### Download VS 2019 for the back-end development 

    https://visualstudio.microsoft.com/downloads/

# Clean Architecture and Project structure and folders

### Application

Contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Domain 

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Infrastruture 

Contains classes for accessing external resources such as file systems, web services, and so on. These classes should be based on interfaces defined within the application layer.

### API (WebUI)

This layer is a single page application based on React and ASP.NET Core 3.1. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only Startup.cs should reference Infrastructure.

### API/ClientApp

This is native CRA 

# Some aspects need be improved which has not enough time to achieve now

### User Authentication not been applied

### WebAPI Docker has issues, only local environment works

### Only CQRS + MediatR not Event Sourcing 

### Test projects 
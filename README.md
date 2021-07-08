# Supermarket.API - Extensions
Simple RESTful API built with ASP.NET Core 2.1 to show how to create RESTful services using a decoupled, maintainable architecture. + extension function + UnitTest(XUnit)

# Test
First, install .NET Core 2.2. Then, open the terminal or command prompt at the API root path (/src/Supermarket.API/) and run the following commands, in sequence:

```
dotnet restore
dotnet run
```
Navigate to http://localhost:5000/api/categories to check if the API is working. If you see a HTTPS security error, just add an exception to see the results.

Navigate to https://localhost:5001/swagger to check the API documentation.

# Architecture
```
├─.github
│  └─ISSUE_TEMPLATE
└─src
    ├─bin
    │  ├─Debug
    │  │  └─netcoreapp2.1
    │  └─Release
    │      └─netcoreapp2.1
    ├─Controllers
    ├─Domain
    │  ├─Models
    │  ├─Repositories
    │  └─Services
    │      └─Communication
    ├─Extensions
    ├─Mapping
    ├─obj
    │  ├─Debug
    │  │  └─netcoreapp2.1
    │  └─Release
    │      └─netcoreapp2.1
    ├─Persistence
    │  ├─Contexts
    │  └─Repositories
    ├─Properties
    ├─Resources
    ├─Services
    └─wwwroot
```
## SwaggerUI
<img src="https://raw.githubusercontent.com/choipureum/Supermarket.API/main/image/swagger_V1.JPG">
# Supermarket.API - Extensions
Simple RESTful API built with ASP.NET Core 2.1 to show how to create RESTful services using a decoupled, maintainable architecture. + extension function + UnitTest(XUnit)

# Test
First, install .NET Core 2.2. Then, open the terminal or command prompt at the API root path (/src/Supermarket.API/) and run the following commands, in sequence:

```
dotnet restore
dotnet run
```
Navigate to https://localhost:5001/api/categories to check if the API is working. If you see a HTTPS security error, just add an exception to see the results.

Navigate to https://localhost:5001/swagger to check the API documentation.

# Architecture
'''
D:.
戍式.github
弛  戌式ISSUE_TEMPLATE
戌式src
    戍式bin
    弛  戍式Debug
    弛  弛  戌式netcoreapp2.1
    弛  戌式Release
    弛      戌式netcoreapp2.1
    戍式Controllers
    戍式Domain
    弛  戍式Models
    弛  戍式Repositories
    弛  戌式Services
    弛      戌式Communication
    戍式Extensions
    戍式Mapping
    戍式obj
    弛  戍式Debug
    弛  弛  戌式netcoreapp2.1
    弛  戌式Release
    弛      戌式netcoreapp2.1
    戍式Persistence
    弛  戍式Contexts
    弛  戌式Repositories
    戍式Properties
    戍式Resources
    戍式Services
    戌式wwwroot
'''
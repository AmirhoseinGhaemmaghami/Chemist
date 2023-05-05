# Chemist

This program is a .Net Web Api that calculates the total price of an order based on the location of the customer and the number of pizzas they have ordered.

## Table of Contents

- [Installation](#installation)
- [Documentation](#documentation)

## Installation

1. Clone this repository to your local machine.
2. Install the .NET6.0 SDK if it is not already installed on your system.
3. Open a terminal or command prompt and navigate to the root directory of the Solution.
4. Run `dotnet restore` to restore the project dependencies.
5. Run `dotnet build` to build the project.
6. Run `dotnet run --project ./Chemist.Api` to start the application.
7. Open a web browser and navigate to the Swagger UI URL, which is located at https://localhost:<port>/swagger/index.html, where <port> is the port number specified in the application runnig. This will display the Swagger UI page, where you can interact with the API.
Use the Swagger UI to test the API endpoints and ensure that they are working correctly. You can also use a tool like Postman to test the API endpoints outside of the Swagger UI.
8. You can use this as a sample input with location = "Southbank" that gets 69 as an output
```json
[
    {
        "name": "Capricciosa",
        "count": 2,
        "toppings": [
            "Cheese",
            "Salami"
        ]
    },
    {
        "name": "Vegetarian",
        "count": 1,
        "toppings": [
        ]
    }
]
```

## Documentation
- In this project I made use of Abstract Factory design pattern because making of the Pizzerias with different menus is a varying part of the code, so I ecnapsulated it. By inheriting `IPizzeriaFactory`, changing menus or adding any other pizzerias is made easy as it would be done only by an inheritance of this interface and registering the new implementation to DI(IOC) container. (So the code is open for extension and close to modification)
- In a real world implementation PizzeriaFactory can fetch the menus and pizzerias from DB
- The project is written in 3 Layer architecture and a Project for test the Services layer
- Each project has registered its services in its own layer in DI folder in its structure
- I made use of AutoMapper library for mapping between the API DTO and domain model (Although they are exactly the same in this project!) as it is insecure to expose domain model to the external world
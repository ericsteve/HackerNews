# Hacker News API

Hello, this is a project to consume and retrieve the best stories of the Hacker News API.

## How to run?

#### Visual Studio
1. Clone the project
2. Build it
3. Push F5. 

You will be prompted with the swagger API where you can test the request.
The Web API returns 20 best stories by default but it is configurable.

#### Cmd
1. Clone the project using git
2. Build it using dotnet build command
3. Run it using dotnet run command.

You can test the request through the endpoint: https://localhost:5001/api/Stories/Best
Swagger: https://localhost:5001/swagger/

## Implementation
I have assumed that the application would grow in the future and I have designed the application using DDD concept, having applied dependency injection, asynchronous and parallel programming for the best performance.
To not overload the Hacker News API, I have implemented cache for 120 seconds (it can be changed on the appsettings.json)

## Enhancements

  - Logging
  - Create a summary for all the methods and properties
  - Add a parameter to manage how many stories to retrieve
  - Authorization for requests

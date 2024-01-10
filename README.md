# POC
This POC is develop using .NET environments, leveraging ASP.NET Core Web API applications, handling events through RabbitMQ, incorporating API Gateways utilizing Ocelot API Gateway. Utilizing both Relational and Non-relational databases, and implementing Entity Framework Core as the Object-Relational Mapping (ORM) tool. 

# TOOLS 
Microsoft Visual Studio Solution File, Format Version 12.00

Visual Studio Version 17

VisualStudioVersion = 17.6.33815.320

MinimumVisualStudioVersion = 10.0.40219.1

SQL server 2017

.Net 7.0

## Run and debug Start
1. Clone the repository to your local machine.
    ```
    git clone https://github.com/sachin-manore/poc.git
    ```
2. Create DataBase by running SQL Script.
    ```
    poc\DataBase\SQL_Script.sql
    ```
3. Add connection string in Service1\ServiceName.Api.Web\appsettings.json.
    ```
    "poc_entities": "Server=;Initial Catalog=;Persist Security Info=False;User ID=;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"
    ```

5. Add integration API details.
```
    IntegrationEnpoint: https://v3.football.api-sports.io/fixtures
    IntegrationApiKey: {Your Api key}
    IntegrationApiHost: v3.football.api-sports.io
```
6. How to generate Integration Api Key
   ```
   http://www.api-football.com/documentation-v3#section/Authentication
   ```
   
##Construct and execute the application using IISExpress

###Configure multiple startup projects
```
   1. Begin by right-clicking on the .sln file.
   2. Opt for "Configure Startup projects."
   3. Choose the "Multiple startup projects" option.
   4. Pick the ApiGateways Project and designate the action as "Start."
   5. Choose the ServiceName.Api.Web Project and set the action to "Start" as well.
   Initiate the application.
  ``` 
By default, the ServiceName.Api.Web service will be accessible at ```https://localhost:44324/``` while ApiGateways will be available at ```https://localhost:44325/.```

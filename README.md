# POC
This POC is develop using .NET environments, leveraging ASP.NET Core Web API applications, handling events through RabbitMQ, incorporating API Gateways utilizing Ocelot API Gateway. Utilizing both Relational and Non-relational databases, and implementing Entity Framework Core as the Object-Relational Mapping (ORM) tool. 

##TOOLS 
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
3. Add connection string in appsettings.json.
    
    ```
    "ConnectionStrings": {
    "poc_entities": "Server={Your Server Name};Initial Catalog={DataBase Name};Persist Security Info=False;User ID={User Id};Password={Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"
  }
```

4. Add integration API details.
    ```
    "appsettings": {

    "IntegrationEnpoint": "https://v3.football.api-sports.io/fixtures",
    "IntegrationApiKey": "{Your Api key}",
    "IntegrationApiHost": "v3.football.api-sports.io"

  }
    ```
Build an run application using IISExpress
Default Service will run on ```https://localhost:44324/```
API Gateways will run on ```https://localhost:44325/```

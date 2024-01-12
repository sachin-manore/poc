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
   
## Construct and execute the application using IISExpress

### Configure multiple startup projects
```
   1. Begin by right-clicking on the .sln file.
   2. Opt for "Configure Startup projects."
   3. Choose the "Multiple startup projects" option.
   4. Pick the ApiGateways Project and designate the action as "Start."
   5. Choose the ServiceName.Api.Web Project and set the action to "Start" as well.
   Initiate the application.
  ``` 
By default, the ServiceName.Api.Web service will be accessible at ``` https://localhost:44324/ ``` while ApiGateways will be available at ``` https://localhost:44325/. ```

## Testing with Swagger (ServiceName.Api.Web)

1. Open your web browser and navigate to the Swagger UI for your API. Typically, it should be something like: 
    
    https://localhost:44324/swagger/index.html. 
    
    
2. Look for the listed API endpoints, and find the /sport/syncdatafromapi endpoint.
    
3. Click on the /sport/syncdatafromapi endpoint to expand it.
    
4. Once expanded, you should see a "Try it out" button. Click on it.
    
5. Then, click the "Execute" button.
    
6. Review the response from the API. If the sync is successful, you can proceed to the next step.
    
7. Now, find the /sport/getfixtures endpoint and repeat the process: click on it, click "Try it out," and click "Execute."
    
8. Review the response to ensure that you are getting the synced data from the application database.

## Testing with ApiGateways
1. Open your preferred API testing tool or use a web browser.

2. Send a GET request to the following URL to sync third-party sport API data:

```
https://localhost:44325/sport/syncfixture
```
3. Check the response to ensure that the data is successfully synchronized with the application database.

4. Send another GET request to the following URL to retrieve synced data from the application database:

```
https://localhost:44325/sport/getfixtures
```
5. Review the response to confirm that you are getting the synced data.

Note - These steps assume that your API is running locally on the specified ports, and you have the necessary permissions to access the endpoints. Adjust the URLs accordingly if your API is hosted differently.

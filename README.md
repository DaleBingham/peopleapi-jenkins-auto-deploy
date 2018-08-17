# People API .NET Core and MSSQL Express Linux
This is a single .net core API microservice with SQL Server Express on Linux backend as a POC. It is to show how to do a single API around a particular domain with a database that is its own. This requires Docker, .NET Core 2.1 (or latest), and a web browser to run. Optionally you can use a SQL tool such as SQL Server Management Studio to view the database if you so desire. Copied from https://github.com/DaleBingham/microservice-with-mssqldb.

Optionally, point Jenkins to the Jenkinsfile and setup your environment to match. You will need a token for a user to go into Jenkins for the authentication to OpenShift.

## Setup

Feel free to clone and/or download this and use as you will. If there are edits you can certainly hit me up, make issues, do PR's, etc. No "man" is an island...

### If you want to build the images and then run docker-compose up -d
* go to the database and run 'docker build -t peopleapi-db .' to build that SQL Express image locally
* go to the peopleapi directory and run 'docker build -t peopleapi .' to build the .NET Core Web API image locally
* from the root run 'docker-compose up -d' to run as a daemon or 'docker-compose up' to run interactively and see all logs

### If you want to do yourself you can follow these steps
* dotnet new webapi -o peopleapi under .net core 2.1.x
* run the SQL script in the database directory
* dotnet ef dbcontext scaffold "server=localhost; user id=peopleAPI; password=myP@ssw0rd; Initial Catalog=peopleAPI"  Microsoft.EntityFrameworkCore.SqlServer
* dotnet ef migrations add PeopleAPIMigration
* dotnet ef database update
* run the SQL and web independently using SQL Server / Express and VS Code

## Building the Database Containers

The database container is built using the Dockerfile in the database directory. It spools up the MS SQL SQL Express Linux container, copies in a create script, runs it, then powers down SQL Express leaving you with a prebuilt database with a horrible password! 

docker run -d -p 1433:1433 --rm --name peopleapi-db peopleapi-db


## API Calls

GET http://localhost:xxxx/swagger/ gives you the Swagger API documentation generated from the Person Controller where xxxx is the port 5000 or whatever you set it to be.

GET http://localhost:xxxx/api/people/ gets back a JSON listing of the all people in the API via a list of Person class objects.

GET http://localhost:xxxx/api/people/71ab7dfc-953f-4821-b221-dcb3cf135068 gets back a JSON listing of the Person class for my record :).

POST http://localhost:xxxx/api/people/ will create the record with the payload below
```
{
    "personId":"900e41ff-29ab-4a03-800b-8c58035c9260",
    "firstName":"Peter","middleName":"Richard",
    "lastName":"O'Toole","address":null,"city":"Annapolis",
    "state":"Maryland","zipCode":"21403","workPhone":"410-555-1212",
    "cellPhone":"443-555-1212","email":"potme@gmail.com",
    "twitter":"thetooler","linkedin":"PeterOT"
}
```

PUT http://localhost:xxxx/api/people/900e41ff-29ab-4a03-800b-8c58035c9260 will update the record with the payload below
```
{
    "personId":"900e41ff-29ab-4a03-800b-8c58035c9260",
    "firstName":"Peter","middleName":"Richard",
    "lastName":"O'Toole","address":null,"city":"Annapolis",
    "state":"Maryland","zipCode":"21403","workPhone":"410-555-1212",
    "cellPhone":"443-555-1212","email":"potme@gmail.com",
    "twitter":"thetooler","linkedin":"PeterOT"
}
```

## DB Structure

There is a single table for 'Person' that has the following fields in a very, very simple layout for this concept:
* PersonID - Guid that is the PK
* FirstName
* MiddleName
* LastName
* Address
* City
* State
* ZipCode
* WorkPhone
* CellPhone
* Email
* Twitter
* Linkedin

## ToDo's still
* Document better
# Retail Store Inventory App (Dockerized)

This is a Dockerized .NET 8 Web Application for managing a retail store’s inventory. It uses Microsoft SQL Server 2019 as the database, both running in separate containers managed by Docker Compose.

## Docker Hub Images

.NET Web App: https://hub.docker.com/r/laibakhalid694/web  
SQL Server Image: https://hub.docker.com/r/laibakhalid694/custome-sqlserver

## How to Run the Project

1. Make sure Docker is installed and running.

2. In the project root folder, run this command to build and start the containers:

```bash
docker-compose -f custom-inventory-compose.yml up --build
```
## Access

- Web App: http://localhost:5000  
- SQL Server: localhost:1433

## SQL Server Credentials

Username: SA  
Password: Dotnet@123

## Pushing Docker Images to Docker Hub

To tag and push your images:

docker tag custome-sqlserver laibakhalid694/custome-sqlserver
docker tag web laibakhalid694/web

docker push laibakhalid694/custome-sqlserver
docker push laibakhalid694/web


# CarAdverts

## Installation Guide
1.  Download repository from here.
2.  Please go to solution folder and type to cmd "docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d". 
    This will create orchestrated container and start all needed services.
3.  From Sql Server Management Studio(SSMS) Login with
  - Username: sa
  - Password: com1234@
4.  With SSMS Login, create a db named "CarAdvertsDb"
5. Import 2 CSV files and create tables in CarAdvertsDb. You can find CSV files in "src\Repository\Repository.API\Assets\DatabaseTables" folder.
6. After all these steps, you can use API's on "localhost:6876" , if you want to go through swagger just type "localhost:6876/swagger" to your browser.

## Project Info
  * Adverts => API Endpoint service for the project.
  * Common => For common service RabbitMQ Queue system.
  * Repository => Microservice for processing database operations.

## Technologies Used
* .NET 5
* Docker
* MsSQL
* RabbitMQ
* Dapper
* Microservices
* DI
* Design Patterns

## Downside
1. I was using Dapper first time so I am not sure if it's optimum. (EntityFrameworkCore was my way to go)
2. There is no logging system for now but it is easy to do it with Elasticsearch since all project runs like microservices.
3. There is no error handling in Repository Microservice for now, but it will be just same as Adverts.API's services error handling so you can check.
4. Could not find to export these all Docker images at once so Insallation would be easier without creating database or importing tables. This is mostly because Dapper does not have code first approach (at least I could not find it).

## Contact
Contact me for any question on my phone or with my email!



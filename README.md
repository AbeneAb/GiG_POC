**GiG Coding Challenge**


I have used Clean Architecture for this POC, and here is how it is organized.
This project is organized in such a way that there is loose coupling between layers and embraces dependency inversion principle. At the core of the application is **Odds.Domain** where entities,interfaces, domain exceptions and seeds are defined. The domain is independent of any feature laden tool or framework, which makes it ideal for long term use. On top of this layer is the **Odds.Application** layer where we have our CQRS implementation,Fluent validation and Publisher for our events and messages.Next in line of dependency id **Odds.Infrastructure** layer where frameworks and tools are used. This project uses Entity framework core as our ORM & Postgres database for storage.

**A little about the Domain Entities Design**

*We have **Categories** where we define differnt activies Like Football, Basketball,Formula 1 and so on. So I have assumed that *Category* Entity is an aggregate root. Under Category we have different **Regions** like Spain,England,Germany, USA and so on, where each region has it own **Competition** where there are going to be one or more **Participant** participating in an **Events.** So for each event we are going to have **Markets** and **Participant Detail**. Each Market will have offers called **Selection**, where we are going to have our Odds. To elaborate furthur Let's take **Euro** 2020 as an example. A game between **Spain and Denmark** is an event.We will have **Markets** like <ins>Match Winner, Goals Under 2.5</ins> and so on. The values for markets will be contained by our **selection** which may be <ins>Spain</ins> <ins>Draw</ins> or <ins>Denmark</ins> for our <ins>Match winner</ins> market. The selection will hold the odds along with index and other fields like label. So we have API controllers defined for various business points. But the main scope of the project, as I understand it is around **Selection Entity**.*

---

## Project Structure

The project is orgainized with microservice architecture in mind, hence I have 
#### Odds Service
* Implemented **DDD, CQRS, and Clean Architecture** with Best Practices.
* Developed **CQRS with using MediatR, FluentValidation  packages**
* Producing **RabbitMQ** Selection event queue by using **MassTransit-RabbitMQ** Configuration
* **Postgres database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to DB on application startup.
#### Docker Compose  with all dependencies on docker;
* Containerization of API,DB PgAdmin & RabbitMQ
* Containerization of databases
* Override Environment variables
#### Selection Event Console Application
* * Implement **Retry and Circuit Breaker patterns** with exponential backoff with IHttpClientFactory and **Polly policies**

## Running The Project
We will need the following tools:

* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
* [.Net Core 5 or later](https://dotnet.microsoft.com/download/dotnet-core/5)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)

Follow these steps to get your development environment set up: (Before Running Start the Docker Desktop)
1. Clone the repository
. At the root directory which include **docker-compose.yml** files, run below command:
```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```


 You can use:

* **Odds API -> http://host.docker.internal:8000/swagger/index.html**
* **Rabbit Management Dashboard -> http://host.docker.internal:15672**   -- guest/guest

* **pgAdmin PostgreSQL -> http://host.docker.internal:5050**   -- admin@odds.com password => admin1234


Thank you.



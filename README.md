# Pokemon Team Manager

An ASP.NET Core + Razor Pages learning project with the PokeAPI.

![Screenshot of Pokemon Team Manager Index Page](/wwwroot/images/index-page-for-github.png)
![Screenshot of Pokemon Team Manager Trainer Page](/wwwroot/images/trainer-page-for-github.png)

## Technologies

- **ASP.NET** Core 6.0
- **Razor Pages**
- **Entity Framework** Core 6.0
- a bit of Web API using ASP.NET Core MVC (remainders from initial attempt)
- Docker
- Authentication and role-based Authorization using **Keycloak** via OIDC
- **Mailhog**
- PostgreSQL
- Redis (for caching even though its useless in this app. I just wanted to try working with it from .NET)
- [PokeAPI](https://pokeapi.co/)

## Conventions

### Domain Language

- Species describes the set of all pokemon of a specific category, e.g. all Dittos.
  - Since species is both singular and plural, we use the incorrect `speciess` with double-s t denote multiple species like in a list of species.

## Development

### Some .NET Commands

```sh
# create new api project in directory `dotnettest` with .net6.0
dotnet new webapi -f net6.0 -o dotnettest
# create .gitignore for .net
dotnet new gitignore

# core commands
dotnet build
dotnet run
dotnet watch

# add package
dotnet add package <package e.g. Microsoft.EntityFrameworkCore.Sqlite>

# entity framework commands
## globally install entity framework CLI
dotnet tool install --global dotnet-ef
## create migration
dotnet ef migrations add InitialCreate --context PizzaContext
## remove all(?) migrations and the snapshot
dotnet ef migrations remove --context PizzaContext
## apply migration
dotnet ef database update --context PizzaContext

## revert migration (2 commands)
dotnet ef database update <previous migration name>
dotnet ef migrations remove
```

### Code Generation

See <https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/model?view=aspnetcore-6.0&tabs=visual-studio-code#add-a-data-model>

### Clearing the (useless :) ) redis cache

tl;dr

```sh
docker exec f1ba8cef8725 redis-cli FLUSHALL
```

Short interactive

```sh
docker exec -it f1ba8cef8725 /bin/bash
redis-cli
FLUSHALL
```

Longer explanation with output

```sh
$ docker ps
CONTAINER ID   IMAGE                  COMMAND                  CREATED        STATUS       PORTS                                       NAMES
f1ba8cef8725   bitnami/redis:latest   "/opt/bitnami/script…"   38 hours ago   Up 2 hours   0.0.0.0:6379->6379/tcp, :::6379->6379/tcp   dotnettest_cache_1
3b819916fdb8   adminer                "entrypoint.sh docke…"   41 hours ago   Up 2 hours   0.0.0.0:8084->8080/tcp, :::8084->8080/tcp   dotnettest_adminer_1
02e2aec63a06   postgres               "docker-entrypoint.s…"   41 hours ago   Up 2 hours   0.0.0.0:5432->5432/tcp, :::5432->5432/tcp   dotnettest_db_1

# replace f1ba8cef8725 by the container id of redis
$ docker exec -it f1ba8cef8725 /bin/bash
I have no name!@f1ba8cef8725:/$ redis-cli
127.0.0.1:6379> FLUSHALL
OK
127.0.0.1:6379>
```

## Resources

- [Auth in ASP.NET](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-6.0)
- [Scaffolding / Code Generation](https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/page?view=aspnetcore-6.0&tabs=visual-studio)
- [OpenID Connect with ASP.net diagram](https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-protocols-oidc) (Note: diagram uses implicit flow, we use the more secure but complicated Authorization Code Flow with PKCE)
- [Razor HTML helpers](https://www.tutorialsteacher.com/mvc/html-helpers)
- [Razor Validation helpers](https://www.tutorialsteacher.com/mvc/htmlhelper-validationmessagefor)

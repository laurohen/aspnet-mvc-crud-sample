# aspnet-mvc-crud-sample


 
## Was used:
- net core
- Entity Framework Core msql
- MVC architecture
- Dockerfile
- dockercompose
- ajax
- bootstrap

## Running project full

```bash
$ docker-compose up
```

## Running the app only

```bash
$ docker build -t aspnet-mvc-crud .
$ docker run -d -p 8080:80 --name app-mvc aspnet-mvc-crud
```
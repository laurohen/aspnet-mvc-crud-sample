#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["aspnet-mvc-crud/aspnet-mvc-crud.csproj", "aspnet-mvc-crud/"]
RUN dotnet restore "aspnet-mvc-crud/aspnet-mvc-crud.csproj"
COPY . .
WORKDIR "/src/aspnet-mvc-crud"
RUN dotnet build "aspnet-mvc-crud.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "aspnet-mvc-crud.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "aspnet-mvc-crud.dll"]
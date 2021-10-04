#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Repository/Repository.API/Repository.API.csproj", "src/Repository/Repository.API/"]
COPY ["src/Repository/Repository.Application/Repository.Application.csproj", "src/Repository/Repository.Application/"]
COPY ["src/Repository/Repository.Core/Repository.Core.csproj", "src/Repository/Repository.Core/"]
COPY ["src/Repository/Repository.Infrastructure/Repository.Infrastructure.csproj", "src/Repository/Repository.Infrastructure/"]
COPY ["src/Common/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "src/Common/EventBusRabbitMQ/"]
RUN dotnet restore "src/Repository/Repository.API/Repository.API.csproj"
COPY . .
WORKDIR "/src/src/Repository/Repository.API"
RUN dotnet build "Repository.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Repository.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Repository.API.dll"]

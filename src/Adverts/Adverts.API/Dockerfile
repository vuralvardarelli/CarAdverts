#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Adverts/Adverts.API/Adverts.API.csproj", "src/Adverts/Adverts.API/"]
COPY ["src/Adverts/Adverts.Core/Adverts.Core.csproj", "src/Adverts/Adverts.Core/"]
COPY ["src/Common/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "src/Common/EventBusRabbitMQ/"]
COPY ["src/Adverts/Adverts.Infrastructure/Adverts.Infrastructure.csproj", "src/Adverts/Adverts.Infrastructure/"]
RUN dotnet restore "src/Adverts/Adverts.API/Adverts.API.csproj"
COPY . .
WORKDIR "/src/src/Adverts/Adverts.API"
RUN dotnet build "Adverts.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Adverts.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adverts.API.dll"]

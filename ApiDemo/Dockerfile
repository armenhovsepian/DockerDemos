﻿# Build stage
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /publish

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /publish
COPY --from=build-env /publish .

ENTRYPOINT ["dotnet", "/publish/ApiDemo.dll"]
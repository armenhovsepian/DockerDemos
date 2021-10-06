# Download the aspnetcore image from the hub repository, so it actually contains the .NET Core and you don’t need to put it inside the image.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base

# Sets our working directory in the app folder, inside the container we are building.
WORKDIR /app

# Copy the contents of the publish folder into the app folder on the image.
COPY ./publish .

# This line tells to docker it should run the dotnet command with AspDotNetCoreApp.dll as parameter.
ENTRYPOINT ["dotnet", "AspDotNetCoreApp.dll"]



FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "AspDotNetCoreApp.dll"]


FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.csproj .
RUN dotnet restore
COPY . .

RUN dotnet build -c Release -o /src/build

FROM build AS publish
RUN dotnet publish -c Release -o /src/publish

FROM base AS final
WORKDIR /publish
COPY --from=publish /src/publish .
ENTRYPOINT ["dotnet", "WebDemo.dll"]
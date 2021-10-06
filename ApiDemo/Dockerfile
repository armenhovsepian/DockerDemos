FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

COPY /bin/Debug/net5.0/publish/ .

ENTRYPOINT ["dotnet", "ApiDemo.dll"]
FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY AzureWebApp1/AzureWebApp1.csproj AzureWebApp1/
RUN dotnet restore AzureWebApp1/AzureWebApp1.csproj
COPY . .
WORKDIR /src/AzureWebApp1
RUN dotnet build AzureWebApp1.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish AzureWebApp1.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AzureWebApp1.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MicroserviceRestApi.csproj", "./"]
RUN dotnet restore "./MicroserviceRestApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MicroserviceRestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroserviceRestApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroserviceRestApi.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Instalacja fontconfig
RUN apt-get update && apt-get install -y \
    fontconfig \
    && mkdir -p /usr/share/fonts/truetype/roboto

# Kopiowanie czcionki do kontenera
COPY Fonts/Roboto_Condensed-Light.ttf /usr/share/fonts/truetype/roboto/

# Aktualizacja cache fontow
RUN fc-cache -f -v

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MicroservicePdfGenerator.csproj", "./"]
RUN dotnet restore "./MicroservicePdfGenerator.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MicroservicePdfGenerator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroservicePdfGenerator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroservicePdfGenerator.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

RUN apt-get update && apt-get install -y \
    fontconfig \
    cron \
    curl \
    && mkdir -p /usr/share/fonts/truetype/roboto
COPY Fonts/Roboto_Condensed-Light.ttf /usr/share/fonts/truetype/roboto/
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

RUN mkdir -p /app/Raports

COPY CronJobs/GenerateAllPupilsPdfCron /etc/cron.d/GenerateAllPupilsPdfCron

RUN chmod 0644 /etc/cron.d/GenerateAllPupilsPdfCron \
    && crontab /etc/cron.d/GenerateAllPupilsPdfCron \
    && touch /var/log/cron.log \
    && chmod 777 /var/log/cron.log

COPY --from=publish /app/publish .
CMD cron && dotnet MicroservicePdfGenerator.dll

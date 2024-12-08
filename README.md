# MicroserviceApp

# Database
## create migration
dotnet ef migrations add NAME
## apply migration
dotnet ef database update


# commands for docker

# schows files in container
docker exec microserviceweb ls


 
## Pingowanie miedzy kontenetami 
- wejdz w dockera 
- apt-get update -y
- apt-get install iputils-ping
- ping -c 4 database  
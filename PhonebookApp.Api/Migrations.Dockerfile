FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["PhonebookApp.Infrastructure/PhonebookApp.Infrastructure.csproj", "PhonebookApp.Infrastructure/"]
COPY ["PhonebookApp.Api/PhonebookApp.Api.csproj", "PhonebookApp.Api/"]
COPY database-update.sh database-update.sh

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "PhonebookApp.Api/PhonebookApp.Api.csproj"
COPY . .
WORKDIR "/src/."

RUN /root/.dotnet/tools/dotnet-ef migrations add "InitialMigrations23" -p PhonebookApp.Infrastructure/ -s PhonebookApp.Api/

RUN chmod +x ./database-update.sh
CMD /bin/bash ./database-update.sh
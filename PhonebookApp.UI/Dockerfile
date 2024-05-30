FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PhonebookApp.UI/PhonebookApp.UI.csproj", "PhonebookApp.UI/"]
COPY ["PhonebookApp.Shared/PhonebookApp.Shared.csproj", "PhonebookApp.Shared/"]
RUN dotnet restore "PhonebookApp.UI/PhonebookApp.UI.csproj"
COPY . .
WORKDIR "/src/PhonebookApp.UI"
RUN dotnet build "PhonebookApp.UI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PhonebookApp.UI.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
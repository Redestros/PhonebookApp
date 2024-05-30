#!/bin/bash

# Wait for Postgres to be ready
#until PGPING=$(nc -w 5 -z postgres 5433); do
#  >&2 echo "Waiting for Postgres..."
#  sleep 1
#done

/root/.dotnet/tools/dotnet-ef database update -p PhonebookApp.Infrastructure/ -s PhonebookApp.Api/ --connection "Host=postgres:5432;Database=phonebook;User ID=postgres;Password=postgres;TrustServerCertificate=true"

#!/bin/bash

echo "Esperando o SQL Server iniciar..."
sleep 15

echo "Rodando migrações do EF Core..."
dotnet ef database update --no-build

echo "Iniciando a API..."
exec dotnet API-Academia.dll
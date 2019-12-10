FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app

COPY . ./
WORKDIR /app/src/Tripod.Service.System

RUN dotnet build \
    && dotnet run
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app

COPY . ./
WORKDIR /app/src/Tripod.Service.Archive

RUN dotnet build \
    && dotnet run
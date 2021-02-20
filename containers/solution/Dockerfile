FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app

COPY src/ ./
RUN dotnet restore ./booster.web

RUN dotnet publish ./booster.web -c Debug -o /booster.web --no-restore
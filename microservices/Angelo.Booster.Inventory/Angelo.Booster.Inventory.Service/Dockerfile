# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
ARG service
ENV serviceProject="$service.Service"

# Copy csproj and restore as distinct layers
COPY microservices/$service/$serviceProject/$serviceProject.csproj .
COPY nuget.config .
COPY ./packages ./packages
RUN dotnet restore

# Copy everything else and build
COPY microservices/$service/$serviceProject .
RUN dotnet publish -c release -o /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
ARG service
ENV serviceDll="$service.Service.dll"
WORKDIR /app
COPY --from=build /app .
COPY ./tools/scripts/wait-for-it.sh .
RUN chmod +x wait-for-it.sh
ENTRYPOINT dotnet $serviceDll
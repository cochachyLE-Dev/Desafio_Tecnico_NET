# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /src

# Copy csproj and restore as distinc layers
COPY src/API.Domain/API.Domain.csproj /API.Domain
COPY src/API.Persistence/API.Persistence.csproj /API.Persistence
COPY src/API.Service/API.Service.csproj /API.Service
COPY src/API.Infrastructure/API.Infrastructure.csproj /API.Infrastructure
COPY src/API/API.csproj /API

# Copy everything else and build
COPY src .
RUN dotnet publish -c Release -o /publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .
ENTRYPOINT ["dotnet", "API.dll"]
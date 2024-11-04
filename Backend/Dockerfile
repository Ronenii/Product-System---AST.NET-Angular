FROM bitnami/aspnet-core:8 AS base
WORKDIR /app
EXPOSE 5145

# Use the SDK image for building the application
FROM bitnami/aspnet-core:8 AS build
WORKDIR /src
COPY . .

# Restore dependencies
RUN dotnet restore

# Build and publish the application
RUN dotnet publish -c Release -o /app/publish

# Copy build output to runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Backend.dll"]
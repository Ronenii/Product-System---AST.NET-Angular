# Use the Bitnami ASP.NET Core SDK image as the base (or replace with mcr.microsoft.com/dotnet/sdk:8.0 if preferred)
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Set the working directory inside the container
WORKDIR /app

# Copy everything from the current directory to the /app directory in the container
COPY . .

# Expose port 5145 for the application
EXPOSE 5145

# Restore dependencies, build, and publish the application
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# Set the entrypoint to run the application on start
ENTRYPOINT ["dotnet", "/app/Backend.dll"]
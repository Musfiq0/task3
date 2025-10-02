# Use the official .NET 8.0 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY task3.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Build and publish the application
RUN dotnet publish -c Release -o out

# Use the official .NET 8.0 runtime image for running
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/out .

# Expose the port (Render will provide PORT environment variable)
EXPOSE 5000

# Run the application
ENTRYPOINT ["dotnet", "task3.dll"]

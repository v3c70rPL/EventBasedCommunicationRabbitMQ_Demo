# Use .NET SDK as the build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
EXPOSE 80
EXPOSE 8080

# Copy and restore Shared project
COPY ./Shared/Shared.csproj ./Shared/
RUN dotnet restore ./Shared/Shared.csproj

# Copy and restore NotificationService project
COPY ./NotificationService/NotificationService.csproj ./NotificationService/
RUN dotnet restore ./NotificationService/NotificationService.csproj

# Copy full source code
COPY ./Shared ./Shared/
COPY ./NotificationService ./NotificationService/

# Build the application
WORKDIR /src/NotificationService
RUN dotnet build -c Release -o /app/build

# Use ASP.NET runtime for running the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy built application
COPY --from=build /app/build ./

# Set entry point
CMD ["dotnet", "NotificationService.dll"]
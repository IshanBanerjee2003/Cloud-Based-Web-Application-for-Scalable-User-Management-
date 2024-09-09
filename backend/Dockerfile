# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

# Build the application
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["backend.csproj", "."]
RUN dotnet restore "./backend.csproj"
COPY . .
WORKDIR "/src/backend"
RUN dotnet build "backend.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "backend.csproj" -c Release -o /app/publish

# Run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend.dll"]

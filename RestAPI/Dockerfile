# Use .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project & install dependencies
COPY *.csproj ./
RUN dotnet restore

# Build project
COPY . ./
RUN dotnet publish -c Release -o out

# Create runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Define container entry point
ENTRYPOINT ["dotnet", "dms.dll"]

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["EchoPOS.csproj", "./"]
RUN dotnet restore "./EchoPOS.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "EchoPOS.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "EchoPOS.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose port and start
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "EchoPOS.dll"]

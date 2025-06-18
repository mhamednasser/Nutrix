# Use the official .NET 8 runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy solution file first
COPY ["graduationProject.sln", "."]
# Copy project file with correct path
COPY ["graduationProject/graduationProject.csproj", "graduationProject/"]
RUN dotnet restore "graduationProject/graduationProject.csproj"

# Copy all source code
COPY . .
WORKDIR "/src/graduationProject"
RUN dotnet build "graduationProject.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "graduationProject.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "graduationProject.dll"]
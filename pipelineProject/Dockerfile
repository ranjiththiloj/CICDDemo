# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["pipelineProject.csproj", "./"]
RUN dotnet restore "pipelineProject.csproj"

# Copy the rest of the source code
COPY . .

# Build the project
RUN dotnet build "pipelineProject.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 2: Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "pipelineProject.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8082
EXPOSE 8083

# Copy published output
COPY --from=publish /app/publish .

# Start the application
ENTRYPOINT ["dotnet", "pipelineProject.dll"]

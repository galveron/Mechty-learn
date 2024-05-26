#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 5073
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#"ConnectionString": "Server=localhost,1433;Database=Mechty;User Id=sa;Password=passWORD123;TrustServerCertificate=true;"zzz
#COPY ["Mechty-learn-backend/Mechty-learn-backend.csproj", "Mechty-learn-backend/"]
#RUN dotnet restore "Mechty-learn-backend/Mechty-learn-backend.csproj"
#COPY . .
#WORKDIR "/src/Mechty-learn-backend"
#RUN dotnet build "Mechty-learn-backend.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "Mechty-learn-backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Mechty-learn-backend.dll"]
#


# Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore
# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Mechty-learn-backend.dll"]
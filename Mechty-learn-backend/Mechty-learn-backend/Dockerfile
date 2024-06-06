# Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 5019

COPY Mechty-learn-backend.csproj ./Mechty-learn-backend/
RUN dotnet restore Mechty-learn-backend/Mechty-learn-backend.csproj

COPY ..
WORKDIR /app/Mechty-learn-backend

RUN dotnet publish -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build-env /app/publish .


RUN dotnet tool install --global dotnet-ef --version 8.0.0
ENV PATH="$PATH:/root/.dotnet/tools"

RUN echo $PATH
RUN ls -la /root/.dotnet/tools
RUN dotnet --info

ENTRYPOINT ["sh", "-c", "dotnet ef database update && dotnet Mechty-learn-backend.dll"]
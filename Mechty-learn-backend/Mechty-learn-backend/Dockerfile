# Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src
EXPOSE 5019
# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore
# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /src/Mechty-learn-backend
COPY --from=build-env /app .


RUN dotnet tool install --global dotnet-ef --version 8.0.0
ENV PATH="$PATH:/root/.dotnet/tools"

RUN echo $PATH
RUN ls -la /root/.dotnet/tools
RUN dotnet --info

ENTRYPOINT ["sh", "-c", "dotnet ef database update --project /Mechty-learn-backend.csproj && dotnet Mechty-learn-backend.dll"]
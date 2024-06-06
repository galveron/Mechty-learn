
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 1000

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY --from=build-env /app .


RUN dotnet tool install --global dotnet-ef --version 8.0
ENV PATH="$PATH:/root/.dotnet/tools"

RUN echo $PATH
RUN ls -la /root/.dotnet/tools
RUN dotnet --info

EXPOSE 1000
ENTRYPOINT ["sh", "-c", "dotnet ef database update", "dotnet Mechty-learn-backend.dll"]

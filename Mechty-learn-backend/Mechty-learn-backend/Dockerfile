
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build-env
WORKDIR /app
EXPOSE 5019

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .


RUN dotnet tool install --global dotnet-ef --version 8.0.0
ENV PATH="$PATH:/root/.dotnet/tools"

RUN echo $PATH
RUN ls -la /root/.dotnet/tools
RUN dotnet --info

ENTRYPOINT ["sh", "-c", "dotnet ef database update --project /Mechty-learn-backend.csproj", "dotnet Mechty-learn-backend.dll"]

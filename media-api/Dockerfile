#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/core/sdk:5.0
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

ENV DOTNET_USE_POLLING_FILE_WATCHER 0

WORKDIR /app

#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["media-api/media-api.csproj", "media-api/"]
RUN dotnet restore "media-api/media-api.csproj"
COPY . .
WORKDIR "/src/media-api"
RUN dotnet build "media-api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "media-api.csproj" -c Debug -o /app/publish



FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "media-api.dll"]
#ENTRYPOINT dotnet watch --project media-api/media-api.csproj run --urls="https://+:51566"
# This will build and launch the server in a loop, restarting whenever a *.cs file changes
#ENTRYPOINT dotnet watch run --no-restore
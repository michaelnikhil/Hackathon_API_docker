#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["media-api/media-api.csproj", "media-api/"]
RUN dotnet restore "media-api/media-api.csproj"
COPY . .
WORKDIR "/src/media-api"
RUN dotnet build "media-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "media-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "media-api.dll"]
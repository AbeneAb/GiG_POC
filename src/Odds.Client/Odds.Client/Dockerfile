#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Odds.Client/Odds.Client/Odds.Client.csproj", "Odds.Client/Odds.Client/"]
COPY ["TopologyCreator/EventBus.Messages/EventBus.Messages.csproj", "TopologyCreator/EventBus.Messages/"]
RUN dotnet restore "Odds.Client/Odds.Client/Odds.Client.csproj"
COPY . .
WORKDIR "/src/Odds.Client/Odds.Client"
RUN dotnet build "Odds.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Odds.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Odds.Client.dll"]
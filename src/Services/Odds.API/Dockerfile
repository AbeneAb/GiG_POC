#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Odds.API/Odds.API.csproj", "Services/Odds.API/"]
COPY ["Services/Odds.Application/Odds.Application.csproj", "Services/Odds.Application/"]
COPY ["Services/Odds.Domain/Odds.Domain.csproj", "Services/Odds.Domain/"]
COPY ["Services/Odds.Repository/Odds.Repository.csproj", "Services/Odds.Repository/"]
RUN dotnet restore "Services/Odds.API/Odds.API.csproj"
COPY . .
WORKDIR "/src/Services/Odds.API"
RUN dotnet build "Odds.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Odds.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Odds.API.dll"]

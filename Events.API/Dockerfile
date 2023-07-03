#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Events.API/Events.API.csproj", "Services/Events/Events.API/"]
COPY ["Events.Application/Events.Application.csproj", "Services/Events/Events.Application/"]
COPY ["Events.Core/Events.Core.csproj", "Services/Events/Events.Core/"]
COPY ["Events.Infrastructure/Events.Infrastructure.csproj", "Services/Events/Events.Infrastructure/"]

RUN dotnet restore "Services/Events/Events.API/Events.API.csproj"
COPY . .
WORKDIR "/src/Services/Events/Events.API"
RUN dotnet build "Events.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Events.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Events.API.dll"]
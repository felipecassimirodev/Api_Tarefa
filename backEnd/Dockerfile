#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Estagio 1
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Estagio 2
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["APITarefas.csproj", "."]
RUN dotnet restore "./APITarefas.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "APITarefas.csproj" -c Release -o /app/build

# Estagio 3
FROM build AS publish
RUN dotnet publish "APITarefas.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Estagio 4
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APITarefas.dll"]
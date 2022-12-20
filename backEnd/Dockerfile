
# Documentação pra inicializar o container

#Gerar imagem do containe
 #Docker build --no-cache -f Dockerfile -t Nome_da_imagem .

#Inicializar imagem 
 #Docker run --name Nome_do_container -p 8000:80  Nome_da_imagem .

#Verifica os containers criados
 #Docker container ls   

#Parar o container
 #Docker stop Nome_do_container

#Remover o container
 #Docker rm Nome_do_container


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:8000;http://+:80;
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["APITarefas.csproj", "."]
RUN dotnet restore "./APITarefas.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "APITarefas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APITarefas.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APITarefas.dll"]
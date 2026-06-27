FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia e restaura as dependências
COPY ["GRC.WebApp/GRC.WebApp.csproj", "GRC.WebApp/"]
COPY ["GRC.Data/GRC.Data.csproj", "GRC.Data/"]
COPY ["GRC.Dominio/GRC.Dominio.csproj", "GRC.Dominio/"]
RUN dotnet restore "GRC.WebApp/GRC.WebApp.csproj"

# Copia o restante do código e compila
COPY . .
WORKDIR "/src/GRC.WebApp"
RUN dotnet build "GRC.WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GRC.WebApp.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \   
    /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# 🔥 PATCH DO OPENSSL: Altera o nível mínimo de segurança do Linux de 2 para 1
RUN sed -i 's/CipherString = DEFAULT@SECLEVEL=2/CipherString = DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf

ENV ASPNETCORE_ENVIRONMENT="Docker"
ENV ASPNETCORE_URLS="http://+:80"

ENTRYPOINT ["dotnet", "GRC.WebApp.dll"]
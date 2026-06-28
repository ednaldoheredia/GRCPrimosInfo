FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["GRC.WebApp/GRC.WebApp.csproj", "GRC.WebApp/"]
COPY ["GRC.Data/GRC.Data.csproj", "GRC.Data/"]
COPY ["GRC.Dominio/GRC.Dominio.csproj", "GRC.Dominio/"]

RUN dotnet restore "GRC.WebApp/GRC.WebApp.csproj"

COPY . .

WORKDIR "/src/GRC.WebApp"

RUN dotnet build "GRC.WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN mkdir -p /root/.aspnet/https/
RUN dotnet dev-certs https -ep /root/.aspnet/https/aspnetapp.pfx -p Teste@123
RUN dotnet dev-certs https --trust

FROM build AS publish
COPY --from=build /root/.aspnet/https/aspnetapp.pfx /root/.aspnet/https/
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "GRC.WebApp.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \   
    /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /root/.aspnet/https/aspnetapp.pfx /root/.aspnet/https/
ENV ASPNETCORE_ENVIRONMENT="Docker"
ENV ASPNETCORE_URLS="https://+:80;https://+:443;"
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="Teste@123"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/root/.aspnet/https/aspnetapp.pfx

ENTRYPOINT ["dotnet", "GRC.WebApp.dll"]
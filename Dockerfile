FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src

COPY ["./app/Skinet.WebApi/Skinet.WebApi.csproj", "./Skinet.WebApi/Skinet.WebApi.csproj"]
COPY ["./app/Skinet.Domain/Skinet.Domain.csproj", "./Skinet.Domain/Skinet.Domain.csproj"]
COPY ["./app/Skinet.Infrastructure/Skinet.Infrastructure.csproj", "./Skinet.Infrastructure/Skinet.Infrastructure.csproj"]
COPY ["./app/Skinet.API.IntegrationTests/Skinet.API.IntegrationTests.csproj", "./Skinet.API.IntegrationTests/Skinet.API.IntegrationTests.csproj"]
COPY ["./app/Skinet.Tests/Skinet.Tests.csproj", "./Skinet.Tests/Skinet.Tests.csproj"]
RUN dotnet restore "./Skinet.WebApi/Skinet.WebApi.csproj" /t:Restore
RUN dotnet restore "./Skinet.API.IntegrationTests/Skinet.API.IntegrationTests.csproj"
RUN dotnet restore "./Skinet.Tests/Skinet.Tests.csproj"

COPY ./app .
WORKDIR "/src/Skinet.WebApi"
RUN dotnet build "Skinet.WebApi.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "Skinet.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./app/Skinet.WebApi/Content ./Content
COPY ["/certificates/", "/usr/local/share/ca-certificates/"]
RUN \
    update-ca-certificates && \
    apt-get update -y && \
    apt-get upgrade -y
ENTRYPOINT ["dotnet", "Skinet.WebApi.dll"]
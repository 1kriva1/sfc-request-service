#base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
LABEL service="SFC.Request.Api" author="Kryvoruk Andrii" email="krivorukandrey@gmail.com"
USER root
WORKDIR /app

#restore & build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ENV HUSKY=False
WORKDIR /source
COPY ["Directory.Build.props", "."]
COPY ["nuget.config", "."]
COPY ["src/API/SFC.Request.Api/SFC.Request.Api.csproj", "src/API/SFC.Request.Api/"]
COPY ["src/Core/SFC.Request.Application/SFC.Request.Application.csproj", "src/Core/SFC.Request.Application/"]
COPY ["src/Core/SFC.Request.Domain/SFC.Request.Domain.csproj", "src/Core/SFC.Request.Domain/"]
COPY ["src/Infrastructure/SFC.Request.Infrastructure/SFC.Request.Infrastructure.csproj", "src/Infrastructure/SFC.Request.Infrastructure/"]
COPY ["src/Infrastructure/SFC.Request.Infrastructure.Persistence/SFC.Request.Infrastructure.Persistence.csproj", "src/Infrastructure/SFC.Request.Infrastructure.Persistence/"]
COPY ["src/Contracts/SFC.Request.Contracts/SFC.Request.Contracts.csproj", "src/Contracts/SFC.Request.Contracts/"]
COPY ["src/Contracts/SFC.Request.Messages/SFC.Request.Messages.csproj", "src/Contracts/SFC.Request.Messages/"]
RUN dotnet restore "./src/API/SFC.Request.Api/SFC.Request.Api.csproj" --property:HUSKY=$HUSKY
COPY [".", "."]
WORKDIR "/source/src/API/SFC.Request.Api"
RUN dotnet build "./SFC.Request.Api.csproj" --configuration $BUILD_CONFIGURATION --property:HUSKY=$HUSKY --output /app/build

#publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SFC.Request.Api.csproj" --configuration $BUILD_CONFIGURATION --property:HUSKY=$HUSKY --property:UseAppHost=false --output /app/publish

#final
FROM base AS final
ARG HTTP_PORT=8080
ARG HTTPS_PORT=8081
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE $HTTP_PORT
EXPOSE $HTTPS_PORT
ENTRYPOINT ["bash", "entrypoint.sh"]
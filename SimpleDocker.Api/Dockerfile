FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["SimpleDocker.Api/SimpleDocker.Api.csproj", "SimpleDocker.Api/"]
RUN dotnet restore "SimpleDocker.Api/SimpleDocker.Api.csproj"
COPY . .
WORKDIR "/src/SimpleDocker.Api"
RUN dotnet build "SimpleDocker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleDocker.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleDocker.Api.dll"]
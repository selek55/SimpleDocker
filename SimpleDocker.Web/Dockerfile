FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["SimpleDocker.Web/SimpleDocker.Web.csproj", "SimpleDocker.Web/"]
RUN dotnet restore "SimpleDocker.Web/SimpleDocker.Web.csproj"
COPY . .
WORKDIR "/src/SimpleDocker.Web"
RUN dotnet build "SimpleDocker.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleDocker.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleDocker.Web.dll"]
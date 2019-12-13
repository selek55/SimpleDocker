FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["./SimpleDocker.Web.csproj", "."]
RUN dotnet restore "SimpleDocker.Web.csproj"
COPY . .
RUN dotnet build "SimpleDocker.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleDocker.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "SimpleDocker.Web.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ["./1.Host/Gateway.api/Gateway.api.csproj", "src/1.Host/Gateway.api/"]

RUN dotnet restore "src/1.Host/Gateway.api/Gateway.api.csproj"

COPY . .

WORKDIR "/src/1.Host/Gateway.api/"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app

COPY --from=publish /app/publish .
RUN ls -l
ENTRYPOINT [ "dotnet", "Gateway.api.dll" ]
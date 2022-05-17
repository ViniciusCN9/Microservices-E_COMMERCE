FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ["./1.Host/Access.api/Access.api.csproj", "src/1.Host/Access.api/"]
COPY ["./2.Domain/Access.domain/Access.domain.csproj", "src/2.Domain/Access.domain/"]
COPY ["./2.Domain/Access.shared/Access.shared.csproj", "src/2.Domain/Access.shared/"]
COPY ["./3.Infra/Access.infra/Access.infra.csproj", "src/3.Infra/Access.infra/"]

RUN dotnet restore "src/1.Host/Access.api/Access.api.csproj"

COPY . .

WORKDIR "/src/1.Host/Access.api/"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app

COPY --from=publish /app/publish .
RUN ls -l
ENTRYPOINT [ "dotnet", "Access.api.dll" ]
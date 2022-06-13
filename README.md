# Microservices-E_COMMERCE
Projeto pessoal para desenvolvimento dos conhecimentos em microsserviços utilizando Docker

## Instruções
Realizar as atualizações no DB para as APIs de acesso e catalogo após subir os containers

 - /Ecommerce: docker compose up
 - /Ecommerce/Acess: dotnet ef database update --project .\1.Host\Access.api\Access.api.csproj
 - /Ecommerce/Catalog: dotnet ef database update --project .\1.Host\Catalog.api\Catalog.api.csproj

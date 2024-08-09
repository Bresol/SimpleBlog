# SimpleBlog

Criar um docker-compose.yaml para SQL server :
```json
version: "3.7"
services:
  sql-server-db:
    container_name: sql-server-db
    image: mcr.microsoft.com/mssql/server:2019-latest
    ports:
      - "1433:1433"
    environment:
      SA_PASSWORD: "SuperSenh@1234"
      ACCEPT_EULA: "Y"
```
# Use official Microsoft SQL Server image
FROM mcr.microsoft.com/mssql/server:2022-latest
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=YourStrong!Passw0rd
ENV MSSQL_PID=Express
EXPOSE 1433
COPY ./init-db.sql /docker-entrypoint-initdb.d/

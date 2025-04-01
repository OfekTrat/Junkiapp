FROM mysql:latest

# Run docker build command in Junkiapp folder
ADD MySqlDB/db-initialization.sql /docker-entrypoint-initdb.d

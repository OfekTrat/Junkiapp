FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ./Junkiapp-App ./
WORKDIR /src

RUN dotnet restore ./JunkiApp.sln
RUN dotnet publish ./JunkiApp.sln -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "JunkiappBackend.dll"]
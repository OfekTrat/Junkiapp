FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ./Junkiapp-App ./
WORKDIR /src

# Restore and publish using the solution
RUN dotnet restore ./JunkiApp.sln

RUN dotnet publish ./JunkiApp.sln -c Release -o /app/publish
    # -p:GenerateAssemblyInfo=false \
    # -p:GenerateTargetFrameworkAttribute=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "JunkiappBackend.dll"]
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["B3Digitas.Todo.Api/B3Digitas.Todo.Api.csproj", "B3Digitas.Todo.Api/"]
COPY ["B3Digitas.Todo.Business/B3Digitas.Todo.Business.csproj", "B3Digitas.Todo.Business/"]
COPY ["B3Digitas.Todo.Data/B3Digitas.Todo.Data.csproj", "B3Digitas.Todo.Data/"]
RUN dotnet restore "./B3Digitas.Todo.Api/B3Digitas.Todo.Api.csproj"
COPY . .
WORKDIR "/src/B3Digitas.Todo.Api"
RUN dotnet build "./B3Digitas.Todo.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./B3Digitas.Todo.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "B3Digitas.Todo.Api.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["citas-backend/citas-backend.csproj", "citas-backend/"]
RUN dotnet restore "citas-backend/citas-backend.csproj"
COPY . .
WORKDIR "/src/citas-backend"
RUN dotnet build "citas-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "citas-backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "citas-backend.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["backend-project-netcore-faf/backend-project-netcore-faf.csproj", "backend-project-netcore-faf/"]
RUN dotnet restore "backend-project-netcore-faf/backend-project-netcore-faf.csproj"
COPY . .
WORKDIR "/src/backend-project-netcore-faf"
RUN dotnet build "backend-project-netcore-faf.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "backend-project-netcore-faf.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend-project-netcore-faf.dll"]
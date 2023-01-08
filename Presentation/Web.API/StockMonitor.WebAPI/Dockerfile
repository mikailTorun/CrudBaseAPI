#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/Web.API/StockMonitor.WebAPI/StockMonitor.WebAPI.csproj", "Presentation/Web.API/StockMonitor.WebAPI/"]
COPY ["Core/StockMonitor.Application/StockMonitor.Application.csproj", "Core/StockMonitor.Application/"]
COPY ["Core/StockMonitor.Domain/StockMonitor.Domain.csproj", "Core/StockMonitor.Domain/"]
COPY ["Infrastructure/StockMonitor.Infrastructure/StockMonitor.Infrastructure.csproj", "Infrastructure/StockMonitor.Infrastructure/"]
COPY ["Infrastructure/StockMonitor.Persistence/StockMonitor.Persistence.csproj", "Infrastructure/StockMonitor.Persistence/"]
RUN dotnet restore "Presentation/Web.API/StockMonitor.WebAPI/StockMonitor.WebAPI.csproj"
COPY . .
WORKDIR "/src/Presentation/Web.API/StockMonitor.WebAPI"
RUN dotnet build "StockMonitor.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StockMonitor.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockMonitor.WebAPI.dll"]
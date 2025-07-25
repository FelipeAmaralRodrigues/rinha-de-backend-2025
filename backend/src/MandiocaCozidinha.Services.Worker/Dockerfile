FROM mcr.microsoft.com/dotnet/runtime:9.0-alpine AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MandiocaCozidinha.Services.Worker/MandiocaCozidinha.Services.Worker.csproj", "MandiocaCozidinha.Services.Worker/"]
COPY ["MandiocaCozidinha.CrossCutting.Contracts/MandiocaCozidinha.CrossCutting.Contracts.csproj", "MandiocaCozidinha.CrossCutting.Contracts/"]
COPY ["MandiocaCozidinha.CrossCutting.PaymentProcessor/MandiocaCozidinha.CrossCutting.PaymentProcessor.csproj", "MandiocaCozidinha.CrossCutting.PaymentProcessor/"]
RUN dotnet restore "MandiocaCozidinha.Services.Worker/MandiocaCozidinha.Services.Worker.csproj"
COPY . .
WORKDIR "/src/MandiocaCozidinha.Services.Worker"
RUN dotnet build "./MandiocaCozidinha.Services.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MandiocaCozidinha.Services.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MandiocaCozidinha.Services.Worker.dll"]
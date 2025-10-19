# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# ✅ Copy từng .csproj (để restore cache hiệu quả)
COPY ["WeddingServer/WeddingServer.csproj", "WeddingServer/"]
COPY ["Core/Core.csproj", "Core/"]

# ✅ Restore dependencies
RUN dotnet restore "./WeddingServer/WeddingServer.csproj"

# ✅ Copy toàn bộ mã nguồn
COPY . .

# ✅ Build project
WORKDIR "/src/WeddingServer"
RUN dotnet build "./WeddingServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WeddingServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeddingServer.dll"]

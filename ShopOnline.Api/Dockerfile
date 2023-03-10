#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShopOnline.Api/ShopOnline.Api.csproj", "ShopOnline.Api/"]
COPY ["ShopOnline.Models/ShopOnline.Models.csproj", "ShopOnline.Models/"]
RUN dotnet restore "ShopOnline.Api/ShopOnline.Api.csproj"
COPY . .
WORKDIR "/src/ShopOnline.Api"
RUN dotnet build "ShopOnline.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopOnline.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopOnline.Api.dll"]
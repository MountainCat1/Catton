FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GuidGenerator/GuidGenerator.csproj", "GuidGenerator/"]
RUN dotnet restore "GuidGenerator/GuidGenerator.csproj"
COPY . .
WORKDIR "/src/GuidGenerator"
RUN dotnet build "GuidGenerator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GuidGenerator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GuidGenerator.dll"]

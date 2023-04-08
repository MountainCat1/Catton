FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["KeyGenerator/KeyGenerator.csproj", "KeyGenerator/"]
RUN dotnet restore "KeyGenerator/KeyGenerator.csproj"
COPY . .
WORKDIR "/src/KeyGenerator"
RUN dotnet build "KeyGenerator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KeyGenerator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KeyGenerator.dll"]

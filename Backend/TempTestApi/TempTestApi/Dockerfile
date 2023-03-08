FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TempTestApi/TempTestApi.csproj", "TempTestApi/"]
RUN dotnet restore "TempTestApi/TempTestApi.csproj"
COPY . .
WORKDIR "/src/TempTestApi"
RUN dotnet build "TempTestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TempTestApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TempTestApi.dll"]

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CsharpCodeGen/CsharpCodeGen.csproj", "CsharpCodeGen/"]
RUN dotnet restore "CsharpCodeGen/CsharpCodeGen.csproj"
COPY . .
WORKDIR "/src/CsharpCodeGen"
RUN dotnet build "CsharpCodeGen.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CsharpCodeGen.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CsharpCodeGen.dll"]

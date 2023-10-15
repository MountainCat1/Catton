FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ApiGateway/ApiGateway.csproj", "ApiGateway/"]
RUN dotnet restore "ApiGateway/ApiGateway.csproj"
COPY . .
WORKDIR "/src/ApiGateway"
RUN dotnet build "ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final

EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:80;https://+:443
ENV ASPNETCORE_HTTPS_PORT=443

WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "ApiGateway.dll"]

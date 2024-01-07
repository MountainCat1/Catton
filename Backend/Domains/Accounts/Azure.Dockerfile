FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Accounts.Api/Accounts.Api.csproj", "Accounts.Api/"]
RUN dotnet restore "Accounts.Api/Accounts.Api.csproj"

COPY . .

WORKDIR "/src/Accounts.Api"

RUN dotnet build "Accounts.Api.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet publish "Accounts.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENV ASPNETCORE_Kestrel__Certificates__Default__Password=PASSWORD
ENV ASPNETCORE_URLS="https://+;http://+" 
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx

ENTRYPOINT ["dotnet", "Accounts.Api.dll"]

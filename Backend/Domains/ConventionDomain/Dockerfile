FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ConventionDomain.Api/ConventionDomain.Api.csproj", "ConventionDomain.Api/"]
RUN dotnet restore "ConventionDomain.Api/ConventionDomain.Api.csproj"
COPY . .
WORKDIR "/src/ConventionDomain.Api"
RUN dotnet build "ConventionDomain.Api.csproj" -c Release -o /app/build
RUN dotnet dev-certs https -ep /https/aspnetapp.pfx -p PASSWORD --trust

FROM build AS publish
RUN dotnet publish "ConventionDomain.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

COPY --from=build /https/* /https/

ENV ASPNETCORE_Kestrel__Certificates__Default__Password=PASSWORD
ENV ASPNETCORE_URLS="https://+;http://+" 
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx

ENTRYPOINT ["dotnet", "ConventionDomain.Api.dll"]

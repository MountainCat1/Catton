ARG ProjectName=Accounts

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

ARG ProjectName

WORKDIR /src
COPY ["$ProjectName.Api/$ProjectName.Api.csproj", "$ProjectName.Api/"]
RUN dotnet restore "$ProjectName.Api/$ProjectName.Api.csproj"
COPY . .
WORKDIR "/src/$ProjectName.Api"
RUN dotnet build "$ProjectName.Api.csproj" -c Release -o /app/build

FROM build AS publish

ARG ProjectName

RUN dotnet publish "$ProjectName.Api.csproj" -c Release -o /app/publish

FROM base AS final

ARG ProjectName

EXPOSE 80

WORKDIR /app
COPY --from=publish /app/publish .

ENV entrypoint="$ProjectName.Api.dll"
ENTRYPOINT ["dotnet", "$entrypoint"]

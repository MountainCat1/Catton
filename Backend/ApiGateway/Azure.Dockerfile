ARG ProjectName=ApiGateway

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

ARG ProjectName

WORKDIR /src
COPY ["$ProjectName/$ProjectName.csproj", "$ProjectName/"]
RUN dotnet restore "$ProjectName/$ProjectName.csproj"
COPY . .
WORKDIR "/src/$ProjectName"
RUN dotnet build "$ProjectName.csproj" -c Release -o /app/build

FROM build AS publish

ARG ProjectName

RUN dotnet publish "$ProjectName.csproj" -c Release -o /app/publish

FROM base AS final

ARG ProjectName

EXPOSE 80

WORKDIR /app
COPY --from=publish /app/publish .

ENV entrypoint="$ProjectName.dll"
ENTRYPOINT "dotnet $entrypoint"





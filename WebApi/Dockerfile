FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
 

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /build
 

COPY *.sln .
 

COPY . /*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done
 

RUN dotnet restore *.sln
 

COPY . .
 

RUN dotnet publish ./WebApi/WebApi.csproj -c Release -o /app/out
 

FROM base as final
WORKDIR /app
 

COPY --from=build-env /app/out .
 
 
ENTRYPOINT ["dotnet", "WebApi.dll"]
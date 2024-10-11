FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5003
 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ApiAgroCare/ApiAgroCare.csproj", "ApiAgroCare/"]
RUN dotnet restore "ApiAgroCare/ApiAgroCare.csproj"
COPY . .
WORKDIR "/src/ApiAgroCare"
RUN dotnet build "ApiAgroCare.csproj" -c Release -o /app/build
 
FROM build AS publish
RUN dotnet publish "ApiAgroCare.csproj" -c Release -o /app/publish
 
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiAgroCare.dll"]
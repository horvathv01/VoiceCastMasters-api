FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VoiceCastMasters-api.csproj", "./"]
RUN dotnet restore "VoiceCastMasters-api.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "VoiceCastMasters-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VoiceCastMasters-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VoiceCastMasters-api.dll"]

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["UsersMicroservice2/UsersMicroservice2.csproj", "UsersMicroservice2/"]
RUN dotnet restore "UsersMicroservice2/UsersMicroservice2.csproj"
COPY . .
WORKDIR "/src/UsersMicroservice2"
RUN dotnet build "UsersMicroservice2.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UsersMicroservice2.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UsersMicroservice2.dll"]
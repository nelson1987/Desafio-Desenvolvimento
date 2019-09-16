FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Desafio.Api/Desafio.Api.csproj", "Desafio.Api/"]
RUN dotnet restore "Desafio.Api/Desafio.Api.csproj"
COPY . .
WORKDIR /src/Desafio.Api
RUN dotnet build "Desafio.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Desafio.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Desafio.Api.dll"]

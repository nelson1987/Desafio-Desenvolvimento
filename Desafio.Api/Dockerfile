#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
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
#Teste de vscode online no github
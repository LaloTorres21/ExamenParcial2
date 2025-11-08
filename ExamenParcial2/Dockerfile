FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["ExamenParcial2/ExamenParcial2.csproj", "ExamenParcial2/"]
RUN dotnet restore "ExamenParcial2/ExamenParcial2.csproj"

COPY . .
WORKDIR "/src/ExamenParcial2"
RUN dotnet publish "ExamenParcial2.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ExamenParcial2.dll"]
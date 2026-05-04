FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

COPY *.slnx .
COPY NoteVault.API/*.csproj ./NoteVault.API/
RUN dotnet restore

COPY . .
RUN dotnet publish NoteVault.API -c Release -o /out

# Etapa 2 — runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "NoteVault.API.dll"]
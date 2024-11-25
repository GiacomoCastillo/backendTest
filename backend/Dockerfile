# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Establecer el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copiar los archivos del proyecto
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del código fuente al contenedor
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Establecer el directorio de trabajo en la etapa de ejecución
WORKDIR /app

# Copiar los archivos construidos de la etapa anterior
COPY --from=build /app/out .

# Exponer el puerto (asegúrate de que tu app esté configurada para escuchar en este puerto)
EXPOSE 5000

# Comando para iniciar la aplicación
ENTRYPOINT ["dotnet", "backend.dll"]
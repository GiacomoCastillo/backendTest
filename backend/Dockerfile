# Etapa 1: Construcci�n
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Establecer el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copiar los archivos del proyecto
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del c�digo fuente al contenedor
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Ejecuci�n
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Establecer el directorio de trabajo en la etapa de ejecuci�n
WORKDIR /app

# Copiar los archivos construidos de la etapa anterior
COPY --from=build /app/out .

# Exponer el puerto (aseg�rate de que tu app est� configurada para escuchar en este puerto)
EXPOSE 5000

# Comando para iniciar la aplicaci�n
ENTRYPOINT ["dotnet",�"backend.dll"]
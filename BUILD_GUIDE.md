# Guía de Compilación - MemoAI

Esta guía te ayudará a crear un ejecutable funcional de MemoAI para distribución.

## 📋 Requisitos Previos

### Software Necesario
- **.NET 8.0 SDK** - [Descargar aquí](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Visual Studio 2022** o **Visual Studio Code** (opcional, para desarrollo)
- **Git** (para clonar el repositorio)

### Verificar Instalación
```bash
# Verificar .NET SDK
dotnet --version
# Debe mostrar 8.0.x o superior
```

## 🚀 Pasos para Crear el Ejecutable

### 1. Clonar el Repositorio
```bash
git clone https://github.com/Davidcrz14/MemoAI.git
cd MemoAI
```

### 2. Restaurar Dependencias
```bash
dotnet restore
```

### 3. Configurar Gmail API

#### 3.1 Crear Proyecto en Google Cloud Console
1. Ve a [Google Cloud Console](https://console.cloud.google.com/)
2. Crea un nuevo proyecto o selecciona uno existente
3. Habilita la **Gmail API**
4. Ve a "Credenciales" → "Crear credenciales" → "ID de cliente OAuth 2.0"
5. Configura como "Aplicación de escritorio"
6. Descarga el archivo JSON de credenciales

#### 3.2 Configurar Credenciales
1. Renombra el archivo descargado a: `client_secret_[tu-client-id].apps.googleusercontent.com.json`
2. Colócalo en la carpeta raíz del proyecto
3. Edita `GoogleConfig.cs` con tus credenciales:

```csharp
public static class GoogleConfig
{
    public static string ClientId = "tu-client-id.apps.googleusercontent.com";
    public static string ClientSecret = "tu-client-secret";
    public static string RedirectUri = "http://localhost:8080/";
}
```

### 4. Compilar en Modo Release

#### 4.1 Compilación Básica
```bash
dotnet build --configuration Release
```

#### 4.2 Publicación Self-Contained (Recomendado)
```bash
# Para Windows x64
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true

# Para Windows x86
dotnet publish -c Release -r win-x86 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```

#### 4.3 Publicación Framework-Dependent (Más pequeño)
```bash
dotnet publish -c Release -r win-x64 --self-contained false -p:PublishSingleFile=true
```

## 📁 Ubicación de Archivos Generados

Después de la compilación, encontrarás los archivos en:

### Self-Contained
```
bin/Release/net8.0-windows/win-x64/publish/
├── MemoAI.exe                    # Ejecutable principal
├── client_secret_*.json          # Credenciales de Google
└── [otros archivos de soporte]   # Solo si es necesario
```

### Framework-Dependent
```
bin/Release/net8.0-windows/win-x64/publish/
├── MemoAI.exe                    # Ejecutable principal
├── MemoAI.dll                    # Biblioteca principal
├── client_secret_*.json          # Credenciales de Google
└── [dependencias .NET]           # Archivos de framework
```

## 📦 Crear Paquete de Distribución

### 1. Crear Carpeta de Distribución
```bash
mkdir MemoAI-Release
cd MemoAI-Release
```

### 2. Copiar Archivos Necesarios
```bash
# Copiar ejecutable y dependencias
copy "..\bin\Release\net8.0-windows\win-x64\publish\*" .

# Copiar archivos de documentación
copy "..\README.md" .
copy "..\LICENSE" .
copy "..\GMAIL_SETUP.md" .
```

### 3. Crear Archivo de Configuración
Crea un archivo `config.txt` con instrucciones para el usuario:

```text
MemoAI - Configuración Inicial
==============================

1. Asegúrate de tener conexión a Internet
2. Al ejecutar por primera vez, se abrirá el navegador para autenticación
3. Inicia sesión con tu cuenta de Gmail
4. Autoriza el acceso a MemoAI
5. ¡Disfruta de tu cliente de correo inteligente!

Soporte: https://github.com/Davidcrz14/MemoAI
```

## 🔧 Opciones Avanzadas de Compilación

### Optimización de Tamaño
```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true -p:TrimMode=link
```

### Compilación con AOT (Experimental)
```bash
dotnet publish -c Release -r win-x64 -p:PublishAot=true
```

### Personalizar Icono de Aplicación
Edita `MemoAI.csproj` y añade:
```xml
<PropertyGroup>
  <ApplicationIcon>icon.ico</ApplicationIcon>
</PropertyGroup>
```

## 🐛 Solución de Problemas

### Error: "No se puede encontrar el archivo de credenciales"
- Verifica que el archivo JSON esté en la carpeta raíz
- Asegúrate de que el nombre coincida con el configurado en `GoogleConfig.cs`

### Error: "Framework no encontrado"
- Instala .NET 8.0 Runtime en el sistema de destino
- O usa compilación self-contained

### Error de Permisos
- Ejecuta como administrador si es necesario
- Verifica que Windows Defender no esté bloqueando el archivo

### Aplicación no inicia
- Verifica que todas las dependencias estén incluidas
- Revisa los logs en el Visor de eventos de Windows

## 📋 Lista de Verificación Final

- [ ] .NET 8.0 SDK instalado
- [ ] Credenciales de Gmail API configuradas
- [ ] Proyecto compilado sin errores
- [ ] Ejecutable funciona en máquina de desarrollo
- [ ] Archivos de documentación incluidos
- [ ] Probado en máquina limpia (sin Visual Studio)

## 🚀 Distribución

### Crear Instalador (Opcional)
Puedes usar herramientas como:
- **Inno Setup** - Gratuito y fácil de usar
- **WiX Toolset** - Más avanzado
- **NSIS** - Ligero y personalizable

### Subir a GitHub Releases
1. Crea un tag de versión: `git tag v1.0.0`
2. Sube el tag: `git push origin v1.0.0`
3. Ve a GitHub → Releases → Create new release
4. Sube el archivo ZIP con el ejecutable

---

**¡Felicidades!** 🎉 Ahora tienes un ejecutable funcional de MemoAI listo para distribuir.

Para más información, visita: [https://github.com/Davidcrz14/MemoAI](https://github.com/Davidcrz14/MemoAI)
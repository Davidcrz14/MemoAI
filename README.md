# MemoAI - Cliente de Correo Inteligente

MemoAI es una aplicación de escritorio moderna para gestión de correos electrónicos con integración de Gmail API y funcionalidades avanzadas de productividad.

## 🚀 Funcionalidades Implementadas

### Gestión de Correos
- ✅ **Bandeja de Entrada Completa**: Visualización de hasta 100 correos con interfaz moderna
- ✅ **Filtros Inteligentes**: Separación entre correos recibidos y enviados con contadores dinámicos
- ✅ **Ordenamiento Cronológico**: Los correos se muestran ordenados por fecha (más recientes primero)
- ✅ **Eliminación de Correos**: Función para mover correos a la papelera con menú contextual
- ✅ **Actualización en Tiempo Real**: Botón de actualizar para sincronizar nuevos correos
- ✅ **Visualización Detallada**: Apertura de correos en ventana completa con formato completo
- ✅ **Autenticación OAuth2**: Integración segura con Gmail usando OAuth 2.0

### Interfaz de Usuario
- ✅ **Diseño Moderno**: Interfaz minimalista con esquema de colores profesional
- ✅ **Navegación Intuitiva**: Sidebar con secciones organizadas (Bandeja, Tareas, Calendario, IA)
- ✅ **Avatares Personalizados**: Iniciales de remitentes con colores distintivos
- ✅ **Responsive Design**: Adaptación automática del contenido
- ✅ **Menús Contextuales**: Acciones rápidas con clic derecho

### Páginas y Secciones
- ✅ **Bandeja de Entrada**: Gestión completa de correos electrónicos
- ✅ **Asistente IA**: Interfaz preparada para funcionalidades de inteligencia artificial
- ✅ **Tareas**: Sección para gestión de tareas (estructura base)
- ✅ **Calendario**: Sección para gestión de calendario (estructura base)
- ✅ **Resúmenes**: Sección para análisis y resúmenes (estructura base)

## 🛠️ Tecnologías Utilizadas

### Framework y Lenguaje
- **C# .NET 8.0**: Lenguaje principal de desarrollo
- **WPF (Windows Presentation Foundation)**: Framework para interfaz de usuario
- **XAML**: Lenguaje de marcado para diseño de UI

### Librerías y Dependencias
- **Google.Apis.Gmail.v1 (1.70.0.3833)**: API oficial de Google para integración con Gmail
- **Google.Apis.Auth (1.70.0)**: Autenticación OAuth2 con Google
- **Google.Apis.Core (1.70.0)**: Funcionalidades base de Google APIs
- **Microsoft.Xaml.Behaviors.Wpf (1.1.77)**: Comportamientos avanzados para WPF
- **Newtonsoft.Json (13.0.3)**: Serialización y deserialización JSON
- **System.Management (7.0.2)**: Gestión del sistema

### Arquitectura y Patrones
- **MVVM Pattern**: Separación de lógica de negocio y presentación
- **Event-Driven Architecture**: Manejo de eventos de UI
- **Async/Await Pattern**: Operaciones asíncronas para mejor rendimiento
- **OAuth 2.0**: Protocolo de autenticación segura

## 🎨 Diseño y UI/UX

### Esquema de Colores
- **Colores Primarios**: Azul profesional (#4F46E5)
- **Backgrounds**: Grises suaves para mejor legibilidad
- **Acentos**: Colores contrastantes para elementos interactivos

### Componentes de UI
- **Borders con CornerRadius**: Elementos redondeados modernos
- **Gradientes Sutiles**: Efectos visuales elegantes
- **Iconografía Consistente**: Emojis y símbolos para mejor UX
- **Tipografía Jerárquica**: Diferentes tamaños y pesos de fuente

## 📁 Estructura del Proyecto

```
MemoAI/
├── Pages/
│   ├── InboxPage.xaml(.cs)     # Bandeja de entrada principal
│   ├── AIPage.xaml(.cs)        # Asistente de IA
│   ├── TasksPage.xaml(.cs)     # Gestión de tareas
│   ├── CalendarPage.xaml(.cs)  # Calendario
│   └── SummaryPage.xaml(.cs)   # Resúmenes
├── MainWindow.xaml(.cs)        # Ventana principal
├── GoogleAuthDialog.xaml(.cs)  # Diálogo de autenticación
├── GoogleConfig.cs             # Configuración de Google API
├── App.xaml(.cs)              # Configuración de aplicación
└── MemoAI.csproj              # Archivo de proyecto
```

## 🔧 Configuración y Requisitos

### Requisitos del Sistema
- Windows 10/11
- .NET 8.0 Runtime
- Conexión a Internet para Gmail API

### Configuración de Gmail API
1. Crear proyecto en Google Cloud Console
2. Habilitar Gmail API
3. Configurar credenciales OAuth 2.0
4. Descargar archivo de credenciales JSON
5. Colocar archivo en directorio del proyecto

## 🚀 Instalación y Ejecución

```bash
# Clonar el repositorio
git clone [https://github.com/Davidcrz14/MemoAI.git]

# Navegar al directorio
cd MemoAI

# Restaurar dependencias
dotnet restore

# Ejecutar la aplicación
dotnet run
```

## 📋 Funcionalidades Futuras (Roadmap)

### Gestión Inteligente de Correos
- Clasificación automática por prioridad e importancia
- Detección de spam y phishing usando IA
- Agrupación automática por temas y proyectos
- Resúmenes automáticos de correos largos
- Entrada Inteligente: "Agrupa los correos de la universidad"

### Asistencia en la Escritura
- Sugerencias de respuestas inteligentes
- Traducción automática multilingüe
- Generación de plantillas personalizadas

### Productividad Avanzada
- Programación inteligente de reuniones
- Extracción automática de tareas y fechas importantes
- Recordatorios contextuales basados en el contenido
- Búsqueda semántica avanzada

### Integración con Herramientas
- Conexión con calendarios y tareas
- Sincronización con otras plataformas

## 🤝 Contribución

Las contribuciones son bienvenidas. Por favor, sigue las convenciones de código existentes y asegúrate de que todas las pruebas pasen.

## 📄 Licencia

Este proyecto está bajo la licencia MIT. Ver el archivo LICENSE para más detalles.

# Configuración de Gmail API para IntelliMail

Esta guía te ayudará a configurar la conexión con Gmail usando la API de Google.

## Paso 1: Crear un proyecto en Google Cloud Console

1. Ve a [Google Cloud Console](https://console.cloud.google.com/)
2. Crea un nuevo proyecto o selecciona uno existente
3. Asegúrate de que el proyecto esté seleccionado en la parte superior

## Paso 2: Habilitar la Gmail API

1. En el menú lateral, ve a **APIs y servicios** > **Biblioteca**
2. Busca "Gmail API"
3. Haz clic en "Gmail API" y luego en **HABILITAR**

## Paso 3: Crear credenciales OAuth 2.0

1. Ve a **APIs y servicios** > **Credenciales**
2. Haz clic en **+ CREAR CREDENCIALES** > **ID de cliente de OAuth 2.0**
3. Si es la primera vez, configura la pantalla de consentimiento:
   - Tipo de usuario: **Externo**
   - Nombre de la aplicación: **IntelliMail**
   - Correo electrónico de asistencia: tu email
   - Dominios autorizados: deja en blanco
   - Correo electrónico del desarrollador: tu email
4. Para el ID de cliente OAuth 2.0:
   - Tipo de aplicación: **Aplicación de escritorio**
   - Nombre: **IntelliMail Desktop**

## Paso 4: Configurar URI de redirección

1. En las credenciales creadas, haz clic en el ícono de edición
2. En **URIs de redirección autorizados**, agrega:
   ```
   http://localhost:8080/callback
   ```
3. Guarda los cambios

## Paso 5: Obtener las credenciales

1. Descarga el archivo JSON de credenciales
2. Abre el archivo y busca:
   - `client_id`: Tu Client ID
   - `client_secret`: Tu Client Secret

## Paso 6: Configurar la aplicación

1. Abre el archivo `GoogleConfig.cs` en tu proyecto
2. Reemplaza los valores:
   ```csharp
   public static string ClientId = "tu-client-id-aqui";
   public static string ClientSecret = "tu-client-secret-aqui";
   ```

## Paso 7: Probar la conexión

1. Ejecuta la aplicación
2. Ve a la Bandeja de Entrada
3. Haz clic en **"Conectar a Google"**
4. Se abrirá tu navegador para autenticarte
5. Autoriza la aplicación
6. Copia el código de autorización de la URL

## Notas importantes

- **Seguridad**: Nunca compartas tus credenciales públicamente
- **Límites**: La API de Gmail tiene límites de uso diarios
- **Scopes**: La aplicación solicita permisos para leer, enviar y modificar emails

## Solución de problemas

### Error: "redirect_uri_mismatch"
- Verifica que `http://localhost:8080/callback` esté en los URIs autorizados

### Error: "invalid_client"
- Verifica que el Client ID y Client Secret sean correctos

### Error: "access_denied"
- El usuario canceló la autorización o hay un problema con los permisos

## Próximos pasos

Una vez configurado, podrás:
- Sincronizar tus emails de Gmail
- Enviar correos desde la aplicación
- Gestionar etiquetas y filtros
- Buscar en tu historial de correos

¿Necesitas ayuda? Revisa la [documentación oficial de Gmail API](https://developers.google.com/gmail/api)

# Proyecto de Evaluación: Sistema de Alquileres

Este repositorio contiene la solución .NET estructurada en 7 capas utilizando Minimal APIs, Entity Framework Core y Windows Forms. A continuación se detalla la arquitectura, dependencias y configuración necesaria para su ejecución.

## 1. Estructura de Proyectos y Referencias

Crea una Solución en blanco y agrega los siguientes 7 proyectos respetando el prefijo `Rallip.`. Configura las dependencias ("Agregar referencia de proyecto") exactamente en este orden:

*   **`Rallip.Domain.Model`** (Biblioteca de clases): No referencia a nadie.
*   **`Rallip.DTOs`** (Biblioteca de clases): No referencia a nadie.
*   **`Rallip.Data`** (Biblioteca de clases): Referencia a `Domain.Model`.
*   **`Rallip.Application.Services`** (Biblioteca de clases): Referencia a `Data`, `Domain.Model` y `DTOs`.
*   **`Rallip.API.Clients`** (Biblioteca de clases): Referencia a `DTOs`.
*   **`Rallip.WebAPI`** (API web de ASP.NET Core): Referencia a `Application.Services` y `DTOs`.
*   **`Rallip.WindowsForms`** (Aplicación de Windows Forms): Referencia a `API.Clients` y `DTOs`.

## 2. Paquetes NuGet Necesarios

*   **En `Data` y `WebAPI`:**
    *   `Microsoft.EntityFrameworkCore.SqlServer`
    *   `Microsoft.EntityFrameworkCore.Tools`
*   **En `API.Clients`:**
    *   `System.Net.Http.Json`

## 3. Resumen de Archivos y Lógica Fundamental

### Capa de Dominio y DTOs
*   **`Alquiler.cs` (Domain) y `AlquilerDTO.cs` (DTOs):** Solo contienen las propiedades puras (`Id`, `Inquilino`, `MontoAlquiler`, `FechaInicio`, `FechaFin`, `Estado`). No llevan atributos ni validaciones.

### Capa de Datos (`Rallip.Data`)
*   **`TPIContext.cs`:** Hereda de `DbContext`.
    *   *Lo clave:* En `OnConfiguring` se define la cadena de conexión a SQL Server (`Server=.\SQLEXPRESS;Database=dbAlquiler...`). En `OnModelCreating` se usa Fluent API para forzar que `Id` sea autoincremental y que `Inquilino` sea obligatorio.
*   **`IAlquilerRepository.cs` y `AlquilerRepository.cs`:** Manejan las consultas directas a la base de datos usando Entity Framework (`AddAsync`, `GetByEstadoAsync`, etc.).

### Capa de Negocio (`Rallip.Application.Services`)
*   **`IAlquilerService.cs` y `AlquilerService.cs`:** Contienen las reglas del negocio solicitadas.
    *   *Lo clave en Agregar:* Valida mediante `if` que el inquilino no esté vacío, que el monto esté entre 0 y 1.000.000, y que las fechas sean lógicas. Lanza un `ArgumentException` si algo falla. Aquí mismo se hardcodea `Estado = "Activo"` antes de guardar.
    *   *Lo clave en Finalizar:* Busca el alquiler por ID y, si existe y está activo, cambia su propiedad a `"Finalizado"` y actualiza la base.

### Capa de Servicios (`Rallip.WebAPI`)
*   **`AlquilerEndpoints.cs`:** Expone las rutas de la Minimal API.
    *   *Lo clave:* El endpoint `MapPost` está envuelto en un `try-catch`. Si atrapa un `ArgumentException`, devuelve un error 400 (BadRequest). Si atrapa una excepción de base de datos, devuelve un error 500 (Problem), evitando que la API corte la conexión abruptamente.
*   **`Program.cs`:** Configura la inyección de dependencias (`AddScoped` asociando las interfaces con sus implementaciones concretas), activa Swagger y mapea los endpoints.
*   **`launchSettings.json` (en Properties):** Define los puertos de ejecución.
    *   *Lo clave:* Se fija un puerto constante (ej. `http://localhost:5184`) para asegurar que el cliente sepa siempre dónde apuntar.

### Capa de Clientes (`Rallip.API.Clients`)
*   **`BaseApiClient.cs`:** Inicializa el `HttpClient`.
    *   *Lo clave:* Define la `BaseAddress` apuntando exactamente al puerto configurado en el `launchSettings.json` de la API.
*   **`AlquilerApiClient.cs`:** Utiliza `PostAsJsonAsync`, `GetFromJsonAsync` y `PutAsync` para comunicarse con la API de forma asíncrona.

### Capa de Presentación (`Rallip.WindowsForms`)
*   **`FormListado.cs`:** Maneja la grilla y los filtros.
    *   *Lo clave:* El botón "Finalizar" se deshabilita por defecto y solo se habilita usando el evento `SelectionChanged` de la grilla cuando el usuario realmente selecciona una fila.
*   **`FormAlta.cs`:** Pantalla de creación sin selector de Estado.
    *   *Lo clave:* Antes de instanciar el DTO y llamar a la API, utiliza `decimal.TryParse` para validar que el texto ingresado en Monto sea un número válido y evalúa los rangos para evitar viajes innecesarios al servidor.

## 4. Configuraciones Finales de Ejecución

1.  **Migraciones:** En la Consola del Administrador de Paquetes, selecciona el proyecto **`Rallip.Data`** como predeterminado. Ejecuta `Add-Migration Inicial` y luego `Update-Database` para generar la base de datos `dbAlquiler` en tu SQL Server.
2.  **Arranque Múltiple:** Haz clic derecho en la Solución -> **Propiedades** -> **Proyectos de inicio múltiples**. Configura la acción **"Iniciar"** tanto para **`Rallip.WebAPI`** como para **`Rallip.WindowsForms`** (asegurando que WebAPI esté primera en la lista).

# Api #1 Obtener El Cuadrado De Un Número

## Api de calcular el cuadrado de un número
Es una Api web en .Net que recibe un número y devuelve el cuadrado.

## Entre las características:
* El Endpoint Get (`/api/Math/cuadrado/numero`) que es para calcular el cuadrado de un número, en /numero ingresar el numero a elevar.
* Validación para evitar números negativos.

## Evidencia de las pruebas locales:
Capturas mostrando que la Api funciona correctamente:

### Prueba 1 con el número 2
![Prueba con el número 2](./CapturasEvidencias/Prueba1.png)

### Prueba 2 con el número 5
![Prueba con el número 5](./CapturasEvidencias/Prueba2.png)

### Prueba 3 con el número 10
![Prueba con el número 10](./CapturasEvidencias/Prueba3.png)

### Prueba 4 con el número negativo -3
![Prueba con el número negativo -3](./CapturasEvidencias/Prueba4Error.png)

# Api #2 Retorno De Datos desde Base de Datos

## Api De Obtener Lista De Producto De Base de Datos Mediante Somee Y Conexión con Dapper

Es una Api web en .Net que se conecta a la base de datos  Sql Server en la nube con somee.com conectada mediante Dapper y devuelve la lista de productos.

## Entre las características:
* El Endpoint Get (`/api/productos`) lista de todos los productos.
* Conexión a la base de datos alojada en Somee utilizando Dapper.
* Arquitectura en capas

## Evidencia del Funcionamiento:
Capturas mostrando que la Api funciona correctamente:

*Prueba del endpoint mostrando los productos en JSON:*
![Prueba de lista de productos](./CapturasEvidencias/Tarea2_ListaProductos.png)

# Api #3 Historial de Cálculos y Clientes Blazor WebAssemblY y Windows Forms
## Demo de consumo de Web API y Persistencia con Azure SQL

Esta solución muestra cómo consumir una Web API REST en ASP.NET Core desde dos tipos de clientes, persistiendo el historial de operaciones en una base de datos relacional en la nube:

- Blazor WebAssembly
- WinForms

La API expone el cálculo del Máximo Común Divisor (MCD) y la gestión de un historial persistido en Azure SQL mediante Dapper. Ambos clientes consumen los mismos endpoints REST.

Se implementó una solución completa para el cálculo del Máximo Común Divisor (MCD) con persistencia relacional en la nube, consumo multiplataforma y despliegue continuo:
  
## Clientes Consumidores:
* **Cliente Web Blazor WebAssembly (`BlazorClient`)**:
  * Aplicación web interactiva construida en Blazor que consume la API en Azure mediante `HttpClient`.
  * Componente reactivo `CalculadoraMCD.razor` para ingresar los valores, ejecutar el cálculo y refrescar automáticamente la tabla de historial alojada en Azure SQL.
  * Configuración de políticas de **CORS** en el backend para permitir la comunicación segura entre el navegador y la API.
* **Cliente de Escritorio Windows Forms (`WinFormsClient`)**:
  * Formulario desacoplado (`FrmCalculadoraMcd`) que consume la API desplegada en Azure App Service de forma asíncrona.
  * Visualización y actualización en tiempo real del historial de Azure SQL mediante un `DataGridView` enlazado a un DTO local.
 
## Base de datos (Azure SQL)

Base de datos **Azure SQL Database** (`McdDb`) alojada en la nube:

- **Tabla:** `HistorialCalculo`
- **Acceso a datos con Dapper** para operaciones de inserción, consulta y borrado de alto rendimiento.

### Script de la tabla

```sql
CREATE TABLE HistorialCalculo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Dividendo INT NOT NULL,
    Divisor INT NOT NULL,
    Resultado INT NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
```

## Requisitos
- .NET 10 SDK (o versión correspondiente instalada)
- Visual Studio 2026 o VS Code con C#
- Cuenta de Azure con Azure SQL Database (o una instancia local de SQL Server)

## Ejemplo estructurado para appsettings.json
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=tcp:servidor-ejemplo.database.windows.net,1433;Initial Catalog=MiBaseDeDatosDb;Persist Security Info=False;User ID=admin_usuario;Password=TuPasswordSeguro123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
}
```

## Ejecutar la solución

### 1. Ejecutar la API
```Bash
dotnet run --project MiWebApi/MiWebApi.csproj
```
La API queda disponible localmente o mediante la URL de Azure App Service:
```
Local: https://localhost:7150 (o el puerto asignado)
```
```
Azure: https://api-calculadora-mcd-dfeefuhsgaazgpay.westus3-01.azurewebsites.net/
```

### 2. Ejecutar el cliente Blazor
```Bash
dotnet run --project BlazorClient/BlazorClient.csproj
```

### 3. Ejecutar el cliente WinForms
Desde Visual Studio, selecciona el proyecto WinFormsClient como proyecto de inicio y ejecuta la solución.

O desde consola:

```Bash
dotnet run --project WinFormsClient/WinFormsClient.csproj
```
## Caso de uso principal
La API expone la operación de MCD y el historial persistido:

GET - `/api/mcd?dividendo={dividendo}&divisor={divisor}`: Calcula el MCD y registra automáticamente el cálculo en Azure SQL.

GET - `/api/historial`: Retorna la lista de cálculos almacenados en la base de datos.

GET - `/api/historial/{id}`: Consulta un registro específico por su identificador.

DELETE - `/api/historial/{id}`: Elimina un registro del historial en la base de datos.

## Notas
- El cliente WinForms consume los endpoints directamente sin restricciones de navegador.
- El cliente Blazor requiere que la API tenga CORS habilitado para su origen.
- A diferencia de un almacén en memoria volátil, la persistencia en Azure SQL asegura que los registros se mantengan disponibles ante reinicios o despliegues del servicio.

##
*Elaborado por: Mariela García Tejada*
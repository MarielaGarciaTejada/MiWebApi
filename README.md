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

# Api #3 Historial de Cálculos y Cliente Windows Forms

Se implementó el registro y consulta del historial de operaciones de Máximo Común Divisor (MCD) tanto en la Web API como en el cliente de escritorio:

* **Almacén en memoria (`HistorialCalculoService`)**: Servicio registrado como *Singleton* que almacena las operaciones realizadas (dividendo, divisor, resultado y fecha UTC) de forma segura para entornos multihilo utilizando mecanismos de sincronización (`lock`).
* **Endpoints Minimal API**:
  * `GET /api/math/mcd/{dividendo}/{divisor}`: Calcula el MCD ejecutando el algoritmo de Euclides mediante `MathService` y guarda automáticamente el registro en el historial.
  * `GET /api/historial`: Retorna la lista de todas las operaciones registradas para consumo de los clientes.
* **Cliente Windows Forms (`WinFormsClient`)**: 
  * Formulario desacoplado (`FrmCalculadoraMcd`) que consume la API desplegada en Azure App Service de manera asíncrona mediante `HttpClient`.
  * Visualización y actualización automática del historial de cálculos en un `DataGridView` a través de un DTO local.


##
*Elaborado por: Mariela García Tejada*
using System.Data;
using Microsoft.Data.SqlClient;

namespace MiWebApi.DbContext
{
    public class DapperContext{

        private readonly IConfiguration _configuracion;
        private readonly String _connectionString;
        private readonly string _connectionStringHistorial;

        //Inyectar IConfiguration para leer el archivo de appsettings.json
        public DapperContext(IConfiguration configuracion)
        {

            _configuracion = configuracion;
            // Cadena de conexion de somee usada por ProductoService
            _connectionString = _configuracion.GetConnectionString("SomeeConnection")
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'SomeeConnection' en appsettings.json"); ;

            // Cadena de conexion de Azure sql usada por HistorialCalculoService
            _connectionStringHistorial = _configuracion.GetConnectionString("AzureSQLConnection")
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'AzureSqlConnection' en appsettings.json");

        }

       /* metodo de crear y devolver la conexion a Sql Server
       este metodo es una interfaz de conexion que se puede conectar a cualquier base de datos */
        public IDbConnection CreateConnection()
        { return new SqlConnection(_connectionString); }

        // conexion a la base de datos de azure sql usada para el historial de calculos de mcd
        public IDbConnection CreateHistorialConnection()
        { return new SqlConnection(_connectionStringHistorial); }
    }

}
using System.Data;
using Microsoft.Data.SqlClient;

namespace MiWebApi.DbContext
{
    public class DapperContext{

        private readonly IConfiguration _configuracion;
        private readonly String _connectionString;
        private readonly String _connectionStringHistorial;

        //Inyectar IConfiguration para leer el archivo de appsettings.json
        public DapperContext(IConfiguration configuracion)
        {

            _configuracion = configuracion;
            // Cadena de conexion de somee usada por ProductoService
            _connectionString = _configuracion.GetConnectionString("SomeeConnection") ?? string.Empty;

            // Cadena de conexion de Azure sql usada por HistorialCalculoService
            _connectionStringHistorial = _configuracion.GetConnectionString("AzureSQLConnection");

        }

       /* metodo de crear y devolver la conexion a Sql Server
       este metodo es una interfaz de conexion que se puede conectar a cualquier base de datos */
        public IDbConnection CreateConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new InvalidOperationException("No se configuró la cadena de conexión 'SomeeConnection'.");
            return new SqlConnection(_connectionString); 
        }

        // conexion a la base de datos de azure sql usada para el historial de calculos de mcd
        public IDbConnection CreateHistorialConnection()
        {
            if (string.IsNullOrEmpty(_connectionStringHistorial))
                throw new InvalidOperationException("No se configuró la cadena de conexión 'AzureSQLConnection'.");
            return new SqlConnection(_connectionStringHistorial); 
        }
    }

}
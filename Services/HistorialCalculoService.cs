using Dapper;
using MiWebApi.DbContext;
using MiWebApi.Models;

namespace MiWebApi.Services
{
    public class HistorialCalculoService
    {
        // Conexion Bd con Dapper
        private readonly DapperContext _context;
        public HistorialCalculoService(DapperContext context)
        { _context = context; }

        public async Task<HistorialCalculo> RegistrarAsync(int dividendo, int divisor, int resultado)
        {
            var consulta = @"
                INSERT INTO HistorialCalculo (Dividendo, Divisor, Resultado, Fecha)
                OUTPUT INSERTED.Id, INSERTED.Dividendo, INSERTED.Divisor, INSERTED.Resultado, INSERTED.Fecha
                VALUES (@Dividendo, @Divisor, @Resultado, @Fecha)";

            using var connection = _context.CreateHistorialConnection();

            return await connection.QuerySingleAsync<HistorialCalculo>(consulta, new
            {
                Dividendo = dividendo,
                Divisor = divisor,
                Resultado = resultado,
                Fecha = DateTime.UtcNow
            });
        }

        public async Task<IEnumerable<HistorialCalculo>> GetAllAsync()
        {
            var consulta = "SELECT Id, Dividendo, Divisor, Resultado, Fecha FROM HistorialCalculo ORDER BY Id";

            using var connection = _context.CreateHistorialConnection();
            return await connection.QueryAsync<HistorialCalculo>(consulta);
        }

        public async Task<HistorialCalculo?> GetByIdAsync(int id)
        {
            var consulta = "SELECT Id, Dividendo, Divisor, Resultado, Fecha FROM HistorialCalculo WHERE Id = @Id";

            using var connection = _context.CreateHistorialConnection();
            return await connection.QuerySingleOrDefaultAsync<HistorialCalculo>(consulta, new { Id = id });
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = "DELETE FROM HistorialCalculo WHERE Id = @Id";

            using var connection = _context.CreateHistorialConnection();
            var filasAfectadas = await connection.ExecuteAsync(consulta, new { Id = id });
            return filasAfectadas > 0;
        }

        /* Este codigo es como lo tiene el maestro, sin base de datos
         
        private readonly List<HistorialCalculo> _items = [];
        private readonly Lock _lock = new();
        private int _nextId = 1;

        public HistorialCalculo Registrar(int dividendo, int divisor, int resultado)
        {
            lock (_lock)
            {
                var item = new HistorialCalculo
                {
                    Id = _nextId++,
                    Dividendo = dividendo,
                    Divisor = divisor,
                    Resultado = resultado,
                    Fecha = DateTime.UtcNow
                };
                _items.Add(item);
                return item;
            }
        }

        public IReadOnlyList<HistorialCalculo> GetAll()
        {
            lock (_lock)
            {
                return _items.ToList();
            }
        }

        public HistorialCalculo? GetById(int id)
        {
            lock (_lock)
            {
                return _items.FirstOrDefault(i => i.Id == id);
            }
        }

        public bool Delete(int id)
        {
            lock (_lock)
            {
                var item = _items.FirstOrDefault(i => i.Id == id);
                if (item is null) return false;
                _items.Remove(item);
                return true;
            }
        }
        */
    }

}

using MiWebApi.Models;

namespace MiWebApi.Services
{
    public class HistorialCalculoService
    {
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
    }
}

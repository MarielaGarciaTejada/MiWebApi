namespace MiWebApi.Models
{
    public class HistorialCalculo
    {
        public int Id { get; set; }
        public int Dividendo { get; set; }
        public int Divisor { get; set; }
        public int Resultado { get; set; }
        public DateTime Fecha { get; set; }
    }
}

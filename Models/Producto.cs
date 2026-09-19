namespace MiWebApi.Api.Models
{
   public class Producto
    {
        public int Id_Producto {get; set;}
        public string Nombre {get; set;} = string.Empty;
        public string? Descripcion { get; set; } = string.Empty;
        public decimal Precio {get; set;}
        public int Stock {get; set;}
        public DateTime FechaRegistro{get; set;}
    }
}
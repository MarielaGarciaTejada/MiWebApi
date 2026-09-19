using Dapper;
using MiWebApi.Api.Models;
using MiWebApi.DbContext;
using System.Collections.Generic;

namespace MiWebApi.Services;

public class ProductoService
{
    private readonly DapperContext _context;
    public ProductoService(DapperContext context){
        _context = context;
    }

    public IEnumerable<Producto> ListaProductos()
    {
        var consulta = @"
            SELECT 
                Id_Producto AS Id_Producto, 
                Nombre, 
                Descripcion AS Descripcion, 
                Precio, 
                Stock, 
                FechaRegistro 
            FROM Productos"; 

        using (var connection = _context.CreateConnection())
        {
            // Consulta y devolución de los datos
            return connection.Query<Producto>(consulta);
        }
    }
}
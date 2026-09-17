using Microsoft.AspNetCore.Http.HttpResults;
using MiWebApi.DbContext;
using MiWebApi.Models;
using MiWebApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registro de servicios en el contenedor de dependencias
builder.Services.AddSingleton<MathService>();
builder.Services.AddSingleton<HistorialCalculoService>();

//La política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClientPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5128",
                          "https://localhost:7150",
                          "http://127.0.0.1:5128",
                          "https://127.0.0.1:7150")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});




builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<ProductoService>();

builder.Services.AddScoped<MiWebApi.Services.MathService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseCors("BlazorClientPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Endpoint de cálculo usando MathService e HistorialCalculoService
app.MapGet("/api/math/mcd/{dividendo:int}/{divisor:int}",
    Results<Ok<int>, BadRequest<string>> (int dividendo, int divisor, MathService mathService, HistorialCalculoService historial) =>
    {
        try
        {
            int resultado = mathService.CalcularMcd(dividendo, divisor);
            historial.Registrar(dividendo, divisor, resultado);
            return TypedResults.Ok(resultado);
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    })
.WithName("GetMcd");

// Endpoints del historial
app.MapGet("/api/historial", (HistorialCalculoService historial) =>
    TypedResults.Ok(historial.GetAll()))
    .WithName("GetHistorial");

app.MapGet("/api/historial/{id:int}",
    Results<Ok<HistorialCalculo>, NotFound> (int id, HistorialCalculoService historial) =>
    {
        var item = historial.GetById(id);
        return item is not null ? TypedResults.Ok(item) : TypedResults.NotFound();
    })
.WithName("GetHistorialItem");

app.MapDelete("/api/historial/{id:int}",
    Results<NoContent, NotFound> (int id, HistorialCalculoService historial) =>
        historial.Delete(id) ? TypedResults.NoContent() : TypedResults.NotFound())
    .WithName("DeleteHistorialItem");

app.Run();

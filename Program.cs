using MiWebApi.DbContext;
using MiWebApi.Models;
using MiWebApi.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Servicios y dependencias
builder.Services.AddSingleton<MathService>();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<HistorialCalculoService>();
builder.Services.AddScoped<ProductoService>();

// CORS abierto para cualquier cliente
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClientPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseDeveloperExceptionPage();


app.MapOpenApi();
app.MapScalarApiReference();

app.UseCors("BlazorClientPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// Endpoints de historial
app.MapGet("/api/historial", async (HistorialCalculoService historial) =>
{
    try
    {
        var items = await historial.GetAllAsync();
        return Results.Ok(items);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error en base de datos: {ex.Message}", statusCode: 500);
    }
}).WithName("GetHistorial");

app.MapGet("/api/historial/{id:int}", async (int id, HistorialCalculoService historial) =>
{
    try
    {
        var item = await historial.GetByIdAsync(id);
        return item is not null ? Results.Ok(item) : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error en base de datos: {ex.Message}", statusCode: 500);
    }
}).WithName("GetHistorialItem");

app.MapDelete("/api/historial/{id:int}", async (int id, HistorialCalculoService historial) =>
{
    try
    {
        return await historial.DeleteAsync(id) ? Results.NoContent() : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error en base de datos: {ex.Message}", statusCode: 500);
    }
}).WithName("DeleteHistorialItem");

app.Run();
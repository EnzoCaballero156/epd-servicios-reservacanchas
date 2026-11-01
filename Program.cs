using Microsoft.EntityFrameworkCore;
using ReservaCanchas.Data;
using ReservaCanchas.Repositorios;
using ReservaCanchas.Servicios;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("connMySQL") ??
    throw new NullReferenceException("La cadena de conexión no existe.");

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IRepositorioCancha, RepositorioCancha>();
builder.Services.AddScoped<IRepositorioClientes, RepositorioClientes>();
builder.Services.AddScoped<IRepositorioReservas, RepositorioReservas>();

builder.Services.AddScoped<ServicioCancha>();
builder.Services.AddScoped<ServicioCliente>();
builder.Services.AddScoped<ServicioReserva>();

var app = builder.Build(); 

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ManejoErrores>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 

app.Run();

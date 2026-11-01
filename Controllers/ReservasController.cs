using Microsoft.AspNetCore.Mvc;
using ReservaCanchas.Dtos;
using ReservaCanchas.Modelos;
using ReservaCanchas.Servicios;

namespace ReservaCanchas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservasController(ServicioReserva servicio) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Reserva>> ListarTodos()
    {
        return Ok(servicio.ListarTodos());
    }

    [HttpGet("{codigo}")]
    public ActionResult<Reserva> BuscarPorCodigo(string codigo)
    {
        return Ok(servicio.BuscarPorCodigo(codigo));
    }

    [HttpPost]
    public ActionResult<Reserva> Registrar(CrearReservaRequest request)
    {
        var nuevaReserva = servicio.Crear(request);
        return Created($"api/reservas/{request.Codigo}", nuevaReserva);
    }

    [HttpPatch("{codigo}")]
    public ActionResult<Reserva> Actualizar(string codigo, ActualizarReservaRequest request)
    {
        return Ok(servicio.Actualizar(codigo, request));
    }

    [HttpDelete("{codigo}")]
    public IActionResult Eliminar(string codigo)
    {
        servicio.Eliminar(codigo);
        return NoContent();
    }
}

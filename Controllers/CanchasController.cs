using Microsoft.AspNetCore.Mvc;
using ReservaCanchas.Dtos;
using ReservaCanchas.Modelos;
using ReservaCanchas.Servicios;

namespace ReservaCanchas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CanchasController(ServicioCancha servicio) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Cancha>> ListarTodos()
    {
        return Ok(servicio.ListarTodos());
    }

    [HttpGet("{codigo}")]
    public ActionResult<Cancha> BuscarPorCodigo(string codigo)
    {
        return Ok(servicio.BuscarPorCodigo(codigo));
    }

    [HttpPost]
    public ActionResult<Cancha> Crear(CrearCanchaRequest request) // solo guiarse del ejm del profe para aplicar DTO
    {
        var nuevaCancha = servicio.Crear(request);
        return Created($"api/canchas/{request.Codigo}", nuevaCancha);
    }

    [HttpPut("{codigo}")]
    public ActionResult<Cancha> Actualizar(string codigo, ActualizarCanchaRequest request) // solo guiarse del ejm del profe para aplicar DTO
    {
        return Ok(servicio.Actualizar(codigo, request));
    }

    [HttpPatch("{codigo}/cambiar-estado")]
    public ActionResult<Cancha> CambiarEstado(string codigo) // solo guiarse del ejm del profe para aplicar DTO
    {
        return Ok(servicio.CambiarEstado(codigo));
    }

    [HttpDelete("{codigo}")]
    public IActionResult Eliminar(string codigo)
    {
        servicio.Eliminar(codigo);
        return NoContent();
    }
}

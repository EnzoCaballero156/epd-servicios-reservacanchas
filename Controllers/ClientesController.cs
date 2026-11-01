using Microsoft.AspNetCore.Mvc;
using ReservaCanchas.Dtos;
using ReservaCanchas.Modelos;
using ReservaCanchas.Servicios;

namespace ReservaCanchas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController(ServicioCliente servicio) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Cliente>> ListarTodos()
    {
        return Ok(servicio.ListarTodos());
    }

    [HttpGet("{codigo}")]
    public ActionResult<Cliente> BuscarPorCodigo(string codigo)
    {
        return Ok(servicio.BuscarPorCodigo(codigo));
    }

    [HttpPost]
    public ActionResult<Cliente> Registrar(CrearClienteRequest request)
    {
        var nuevoCliente = servicio.Crear(request); 
        return Created($"api/clientes/{request.Codigo}", nuevoCliente); 
    }

    [HttpPatch("{codigo}")]
    public ActionResult<Cliente> Actualizar(string codigo, ActualizarClienteRequest request)
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

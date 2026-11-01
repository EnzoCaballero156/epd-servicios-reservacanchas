using ReservaCanchas.Dtos;
using ReservaCanchas.Excepciones;
using ReservaCanchas.Modelos;
using ReservaCanchas.Repositorios;

namespace ReservaCanchas.Servicios;

public class ServicioCancha(IRepositorioCancha repositorio)
{
    public List<Cancha> ListarTodos()
    {
        return repositorio.ListarTodos();
    }

    public Cancha BuscarPorCodigo(string codigo)
    {
        var cancha = repositorio.BuscarPorCodigo(codigo) ?? throw new RecursoNoEncontradoException("No existe una cancha con el código consultado.");
        
        return cancha;
    }

    public Cancha Crear(CrearCanchaRequest request)
    {
        if (repositorio.BuscarPorCodigo(request.Codigo) != null)
        {
            throw new ConflictoException("Ya existe una cancha con el código asignado.");
        }

        Cancha nuevaCancha = new(request.Codigo, request.Nombre, request.Tipo, request.PrecioTurno, "Libre"); 

        repositorio.Agregar(nuevaCancha);

        return nuevaCancha;
    }

    public Cancha Actualizar(string codigo, ActualizarCanchaRequest request)
    {
        var cancha = repositorio.BuscarPorCodigo(codigo) ?? throw new RecursoNoEncontradoException("No existe una cancha con el código asignado.");
        
        cancha.Nombre = request.Nombre;
        cancha.Tipo = request.Tipo;
        cancha.PrecioTurno = request.PrecioTurno;

        repositorio.Actualizar(cancha);

        return cancha;
    }

    public Cancha CambiarEstado(string codigo)
    {
        var cancha = repositorio.BuscarPorCodigo(codigo) ?? throw new RecursoNoEncontradoException("No existe una cancha con el código asignado.");
        cancha.Estado = cancha.Estado.Equals("Libre") ? "Ocupado" : "Libre";

        repositorio.Actualizar(cancha);
        
        return cancha;
    }

    public bool Eliminar(string codigo)
    {
        return repositorio.EliminarPorCodigo(codigo);
    }
}
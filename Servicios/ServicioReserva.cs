using ReservaCanchas.Dtos;
using ReservaCanchas.Excepciones;
using ReservaCanchas.Modelos;
using ReservaCanchas.Repositorios;

namespace ReservaCanchas.Servicios;

public class ServicioReserva(
    IRepositorioReservas repositorioReservas, 
    IRepositorioCancha repositorioCancha, 
    IRepositorioClientes repositorioClientes
    )
{
    public List<Reserva> ListarTodos()
    {
        return repositorioReservas.ListarTodos();
    }

    public Reserva BuscarPorCodigo(string codigo)
    {
        var reserva = repositorioReservas.BuscarPorCodigo(codigo) ?? throw new RecursoNoEncontradoException("No existe una reserva con el código consultado.");
        return reserva;
    }

    public Reserva Crear(CrearReservaRequest request)
    {
        if (repositorioReservas.BuscarPorCodigo(request.Codigo) != null)
        {
            throw new ConflictoException("Ya existe un reserva con el código asignado.");
        }

        var cliente = repositorioClientes.BuscarPorCodigo(request.CodCliente) ?? throw new RecursoNoEncontradoException("El cliente no existe.");
        var cancha = repositorioCancha.BuscarPorCodigo(request.CodCancha) ?? throw new RecursoNoEncontradoException("La cancha no existe.");

        Reserva nuevaReserva = new(request.Codigo, cliente, cancha, request.Fecha, request.HoraInicio, request.Estado, request.Precio);
        repositorioReservas.Agregar(nuevaReserva);

        return nuevaReserva;
    }

    public Reserva Actualizar(string codigo, ActualizarReservaRequest request)
    {
        var reserva = repositorioReservas.BuscarPorCodigo(codigo) ?? throw new RecursoNoEncontradoException("No existe una reserva con el código asignado.");
        reserva.Estado = request.Estado;
        repositorioReservas.Actualizar(reserva);

        return reserva;
    }

    public bool Eliminar(string codigo)
    {
        return repositorioReservas.EliminarPorCodigo(codigo);
    }
}
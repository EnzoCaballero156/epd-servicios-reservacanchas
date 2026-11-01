using ReservaCanchas.Dtos;
using ReservaCanchas.Excepciones;
using ReservaCanchas.Modelos;
using ReservaCanchas.Repositorios;

namespace ReservaCanchas.Servicios;

public class ServicioCliente(IRepositorioClientes repositorio)
{
    public List<Cliente> ListarTodos()
    {
        return repositorio.ListarTodos();
    }

    public Cliente BuscarPorCodigo(string codigo)
    {
        var cliente = repositorio.BuscarPorCodigo(codigo) ?? throw new RecursoNoEncontradoException("No existe un cliente con el código consultado.");
        return cliente;
    }

    public Cliente Crear(CrearClienteRequest request)
    {
        if (repositorio.BuscarPorCodigo(request.Codigo) != null)
        {
            throw new ConflictoException("Ya existe un cliente con el código asignado.");
        }

        Cliente nuevoCliente = new(request.Codigo, request.Dni, request.Nombre, request.Apellido, request.Telefono);
        repositorio.Agregar(nuevoCliente);

        return nuevoCliente;
    }

    public Cliente Actualizar(string codigo, ActualizarClienteRequest request)
    {
        var cliente = repositorio.BuscarPorCodigo(codigo) ?? throw new RecursoNoEncontradoException("No existe un cliente con el código asignado.");
        
        cliente.Nombre = request.Nombre;
        cliente.Apellido = request.Apellido;
        cliente.Telefono = request.Telefono;

        repositorio.Actualizar(cliente);

        return cliente;
    }

    public bool Eliminar(string codigo)
    {
        return repositorio.EliminarPorCodigo(codigo);
    }
}
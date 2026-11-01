using ReservaCanchas.Modelos;

namespace ReservaCanchas.Repositorios
{
    public interface IRepositorioClientes
    {
        List<Cliente> ListarTodos();
        Cliente? BuscarPorCodigo(string codigo);
        void Agregar(Cliente cliente);
        bool Actualizar(Cliente cliente);
        bool EliminarPorCodigo(string codigo);
    }
}

using ReservaCanchas.Modelos;

namespace ReservaCanchas.Repositorios
{
    public interface IRepositorioReservas
    {
        List<Reserva> ListarTodos();
        Reserva? BuscarPorCodigo(string codigo);
        void Agregar(Reserva reserva);
        bool Actualizar(Reserva reserva);
        bool EliminarPorCodigo(string codigo);
    }
}

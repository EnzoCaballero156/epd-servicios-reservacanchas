using Microsoft.EntityFrameworkCore;
using ReservaCanchas.Modelos;

namespace ReservaCanchas.Repositorios
{
    public interface IRepositorioCancha
    {
        List<Cancha> ListarTodos();
        Cancha? BuscarPorCodigo(string codigo);
        void Agregar(Cancha cancha);
        bool Actualizar(Cancha cancha);
        bool EliminarPorCodigo(string codigo);
    }
}

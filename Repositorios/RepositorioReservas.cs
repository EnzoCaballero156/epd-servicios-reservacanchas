
using Microsoft.EntityFrameworkCore;
using ReservaCanchas.Data;
using ReservaCanchas.Modelos;

namespace ReservaCanchas.Repositorios
{
    public class RepositorioReservas(ApplicationDbContext context) : IRepositorioReservas
    {
        public List<Reserva> ListarTodos()
        {
            return context.Reservas.ToList();
        }

        public Reserva? BuscarPorCodigo(string codigo)
        {
            return context.Reservas
                .FirstOrDefault(reserva => reserva.Codigo == codigo);
        }

        public void Agregar(Reserva reserva)
        {
            context.Reservas.Add(reserva);
            context.SaveChanges();
        }

        public bool Actualizar(Reserva reserva)
        {
            context.Reservas.Update(reserva);
            var filasAfectadas = context.SaveChanges();
            return filasAfectadas > 0;
        }

        public bool EliminarPorCodigo(string codigo)
        {
            var reserva = context.Reservas
                .FirstOrDefault(reserva => reserva.Codigo == codigo);

            if (reserva == null)
            {
                return false;
            }

            context.Reservas.Remove(reserva);
            var filasAfectadas = context.SaveChanges();
            return filasAfectadas > 0;
        }
    }
}

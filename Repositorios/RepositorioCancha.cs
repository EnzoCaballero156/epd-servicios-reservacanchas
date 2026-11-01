using ReservaCanchas.Data;
using ReservaCanchas.Modelos;

namespace ReservaCanchas.Repositorios
{
    public class RepositorioCancha(ApplicationDbContext context) : IRepositorioCancha
    {
        
        public List<Cancha> ListarTodos()
        {
            return context.Canchas.ToList();
        }

        public Cancha? BuscarPorCodigo(string codigo)
        {
            return context.Canchas
                .FirstOrDefault(cancha => cancha.Codigo == codigo);
        }

        public void Agregar(Cancha cancha)
        {
            context.Canchas.Add(cancha);
            context.SaveChanges();
        }

        public bool Actualizar(Cancha cancha)
        {
            context.Canchas.Update(cancha);
            var filasAfectadas = context.SaveChanges();
            
            return filasAfectadas > 0;
        }

        public bool EliminarPorCodigo(string codigo)
        {
            var cancha = context.Canchas
                .FirstOrDefault(cancha => cancha.Codigo == codigo);

            if (cancha == null)
            {
                return false;
            }

            context.Canchas.Remove(cancha);
            var filasAfectadas = context.SaveChanges();
            return filasAfectadas > 0;
        }
    }
}

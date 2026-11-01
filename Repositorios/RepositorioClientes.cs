using Microsoft.EntityFrameworkCore;
using ReservaCanchas.Data;
using ReservaCanchas.Modelos;

namespace ReservaCanchas.Repositorios
{
    public class RepositorioClientes(ApplicationDbContext context) : IRepositorioClientes
    {
        public List<Cliente> ListarTodos()
        {
            return context.Clientes.ToList();
        }

        public Cliente? BuscarPorCodigo(string codigo)
        {
            return context.Clientes
                .FirstOrDefault(cliente => cliente.Codigo == codigo);
        }

        public void Agregar(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();
        }

        public bool Actualizar(Cliente cliente)
        {
            context.Clientes.Update(cliente);
            var filasAfectadas = context.SaveChanges();
            return filasAfectadas > 0;
        }

        public bool EliminarPorCodigo(string codigo)
        {
            var cliente = context.Clientes
                .FirstOrDefault(cliente => cliente.Codigo == codigo);

            if (cliente == null)
            {
                return false;
            }

            context.Clientes.Update(cliente);
            var filasAfectadas = context.SaveChanges();
            return filasAfectadas > 0;
        }
    }
}

namespace ReservaCanchas.Modelos;

public class Reserva(string codigo, Cliente cliente, Cancha cancha, DateTime fecha, TimeSpan horaInicio, string estado, decimal precio)
{
    public int Id { get; private set; }
    public string Codigo { get; private set; } = codigo;
    public Cliente Cliente { get; set; } = cliente;
    public Cancha Cancha { get; set; } = cancha;
    public DateTime Fecha { get; set; } = fecha;
    public TimeSpan HoraInicio { get; set; } = horaInicio;
    public string Estado { get; set; } = estado;
    public decimal Precio { get; set; } = precio;

    protected Reserva() : this(string.Empty, null!, null!, DateTime.MinValue, TimeSpan.MinValue, string.Empty, 0) { }
}
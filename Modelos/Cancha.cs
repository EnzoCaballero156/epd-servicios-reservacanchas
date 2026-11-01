namespace ReservaCanchas.Modelos;

public class Cancha(string codigo, string nombre, string tipo, decimal precioTurno, string estado)
{
    public int Id { get; private set; }
    public string Codigo { get; private set; } = codigo;
    public string Nombre { get; set; } = nombre;
    public string Tipo { get; set; } = tipo;
    public decimal PrecioTurno { get; set; } = precioTurno;
    public string Estado { get; set; } = estado;

    protected Cancha() : this(string.Empty, string.Empty, string.Empty, 0, string.Empty) { }
}
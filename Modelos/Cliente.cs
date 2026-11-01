namespace ReservaCanchas.Modelos;

public class Cliente : Persona
{
    public int Id { get; private set; }
    public string Codigo { get; private set; }

    public Cliente(string codigo, string dni, string nombre, string apellido, string telefono) : base(dni, nombre, apellido, telefono)
    {
        Codigo = codigo;
    }

    public override string Rol() => "Cliente";

    protected Cliente() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty) { }
}
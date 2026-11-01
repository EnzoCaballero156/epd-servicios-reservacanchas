namespace ReservaCanchas.Modelos;

public abstract class Persona(string dni, string nombre, string apellido, string telefono)
{
    public string Dni {get; set;} = dni;
    public string Nombre {get; set;} = nombre;
    public string Apellido {get; set;} = apellido;
    public string Telefono {get; set;} = telefono;

    public abstract string Rol();
}


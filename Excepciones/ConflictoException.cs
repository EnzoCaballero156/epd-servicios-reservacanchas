namespace ReservaCanchas.Excepciones;

// error personalizado / exception personalizada
public class ConflictoException(string mensaje) : Exception(mensaje)
{
}
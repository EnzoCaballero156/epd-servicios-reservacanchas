using System.ComponentModel.DataAnnotations;

namespace ReservaCanchas.Dtos;

public class ActualizarReservaRequest
{
    [Required(ErrorMessage ="El estado es obligatorio")]
    public string Estado { get; set; } = "";
}


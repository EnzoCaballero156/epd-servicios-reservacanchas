using System.ComponentModel.DataAnnotations;

namespace ReservaCanchas.Dtos;

public class ActualizarCanchaRequest
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
    public string Nombre { get; set; } = "";

    [Required(ErrorMessage = "El Tipo es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El tipo debe tener entre 3 y 100 caracteres")]
    public string Tipo { get; set; } = "";

    [Required(ErrorMessage = "El precio del turno es obligatoria")]
    [Range(0, 1000, ErrorMessage = "El precio debe estar entre 0 y 1000")]
    public decimal PrecioTurno { get; set; }
}

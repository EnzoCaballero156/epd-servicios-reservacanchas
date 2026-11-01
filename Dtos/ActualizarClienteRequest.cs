using System.ComponentModel.DataAnnotations;

namespace ReservaCanchas.Dtos;

public class ActualizarClienteRequest
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
    public string Nombre { get; set; } = "";

    [Required(ErrorMessage = "El apellido es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El apellido debe tener entre 3 y 100 caracteres")]
    public string Apellido { get; set; } = "";

    [Required(ErrorMessage = "El Teléfono es obligatorio")]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "El Teléfono debe tener 9 dígitos")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "El Teléfono solo debe contener números")]
    public string Telefono { get; set; } = "";
}

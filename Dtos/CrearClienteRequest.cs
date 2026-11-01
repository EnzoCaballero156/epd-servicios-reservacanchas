
using System.ComponentModel.DataAnnotations;

namespace ReservaCanchas.Dtos;

public class CrearClienteRequest
{
    [Required(ErrorMessage ="El codigo es obligatorio")]
    [RegularExpression(@"^[A-Z]{3}-\d{4}$", ErrorMessage = "El código debe tener el formato AAA-0000 (3 letras mayúsculas y 4 números).")]
    public string Codigo { get; set; } = string.Empty;

    [Required(ErrorMessage = "El DNI es obligatorio")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "El DNI debe tener 8 dígitos")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "El DNI solo debe contener números")]
    public string Dni { get; set; } = string.Empty;

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El apellido debe tener entre 3 y 100 caracteres")]
    public string Apellido { get; set; } = string.Empty;

    [Required(ErrorMessage = "El Teléfono es obligatorio")]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "El Teléfono debe tener 9 dígitos")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "El Teléfono solo debe contener números")]
    public string Telefono { get; set; } = string.Empty;
}

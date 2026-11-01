using System.ComponentModel.DataAnnotations;
namespace ReservaCanchas.Dtos;

public class CrearReservaRequest
{
    [Required(ErrorMessage ="El codigo es obligatorio")]
    [RegularExpression(@"^[A-Z]{3}-\d{4}$", ErrorMessage = "El código debe tener el formato AAA-0000 (3 letras mayúsculas y 4 números).")]
    public string Codigo { get; set; } = "";

    [Required(ErrorMessage ="El codigo de cliente es obligatorio")]
    [RegularExpression(@"^[A-Z]{3}-\d{4}$", ErrorMessage = "El código de cliente debe tener el formato AAA-0000 (3 letras mayúsculas y 4 números).")]
    public string CodCliente { get; set; } = "";

    [Required(ErrorMessage ="El codigo de la cancha es obligatorio")]
    [RegularExpression(@"^[A-Z]{3}-\d{4}$", ErrorMessage = "El código de la cancha debe tener el formato AAA-0000 (3 letras mayúsculas y 4 números).")]
    public string CodCancha { get; set; } = "";
    public DateTime Fecha { get; set; }
    public TimeSpan HoraInicio { get; set; }

    [Required(ErrorMessage ="El estado es obligatorio")]
    public string Estado { get; set; } = "";

    [Required(ErrorMessage = "El precio del es obligatoria")]
    [Range(0, 1000, ErrorMessage = "El precio debe estar entre 0 y 1000")]
    public decimal Precio { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace ModeloParcial.Web.Models;

public class PilotoViewModel
{
   
    [Required(ErrorMessage = "El campo Nombre es obligatorio")]
    [StringLength(50, ErrorMessage = "El campo Nombre no puede superar los 50 caracteres")]
    [Display(Name = "Nombre de Piloto")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "La Escuderia es obligatoria")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Escuderia")]
    public int IdEscuderia { get; set; }
   
}

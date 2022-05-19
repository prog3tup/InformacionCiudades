using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Controllers
{
    public class PuntoDeInteresParaUpdateDto
    {
        [Required(ErrorMessage = "Agregá un nombre")]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Descripcion { get; set; }
    }
}
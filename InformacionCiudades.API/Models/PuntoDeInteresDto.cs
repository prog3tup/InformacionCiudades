using InformacionCiudades.API.Enums;
using System.Text.Json.Serialization;

namespace InformacionCiudades.API.Models
{
    public class PuntoDeInteresDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TiposPuntosDeInteres TipoPuntoDeInteres { get; set; }
    }
}

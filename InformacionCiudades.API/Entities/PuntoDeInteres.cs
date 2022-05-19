using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InformacionCiudades.API.Entities
{
    public class PuntoDeInteres
    {
        [Key] //Esto es opcional si se sigue la convención
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //También por convención no hace falta. Identity genera un nuevo Id por cada creación.
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        //public string? Descripcion { get; set; } Lo dejamos para después.

        public Ciudad? Ciudad { get; set; }
        public PuntoDeInteres(string nombre)
        {
            Nombre = nombre;
        }
    }
}

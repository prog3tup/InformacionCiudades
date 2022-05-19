using InformacionCiudades.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace InformacionCiudades.API.DBContexts
{
    public class InformacionCiudadesContext : DbContext
    {
        public DbSet<Ciudad> Ciudades { get; set; } //lo que hagamos con LINQ sobre estos DbSets lo va a transformar en consultas SQL
        public DbSet<PuntoDeInteres> PuntosDeInteres { get; set; } //Los warnings los podemos obviar porque DbContext se encarga de eso.

        public InformacionCiudadesContext(DbContextOptions<InformacionCiudadesContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }
    }
}

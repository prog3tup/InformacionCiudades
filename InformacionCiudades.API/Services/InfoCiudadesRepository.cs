using InformacionCiudades.API.DBContexts;
using InformacionCiudades.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace InformacionCiudades.API.Services
{
    public class InfoCiudadesRepository : IInfoCiudadesRepository
    {
        private readonly InformacionCiudadesContext _context;

        public InfoCiudadesRepository(InformacionCiudadesContext context)
        {
            _context = context;
        }
        public Ciudad? GetCiudad(int idCiudad, bool incluirPuntosDeInteres)
        {
            if (incluirPuntosDeInteres)
                return _context.Ciudades.Include(c => c.PuntosDeInteres)
                    .Where(c => c.Id == idCiudad).FirstOrDefault();

            return _context.Ciudades.Where(c => c.Id == idCiudad).FirstOrDefault();
        }

        public IEnumerable<Ciudad> GetCiudades()
        {
            return _context.Ciudades.OrderBy(x => x.Nombre).ToList();
        }

        public PuntoDeInteres? GetPuntoDeInteresDeCiudad(int idCiudad, int idPuntoDeInteres)
        {
            return _context.PuntosDeInteres.Where(p => p.CiudadId == idCiudad && p.Id == idPuntoDeInteres).FirstOrDefault();
        }

        public IEnumerable<PuntoDeInteres> GetPuntosDeInteresDeCiudad(int idCiudad)
        {
            return _context.PuntosDeInteres.Where(p => p.CiudadId == idCiudad).ToList();
        }
    }
}

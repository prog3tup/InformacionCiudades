using AutoMapper;

namespace InformacionCiudades.API.AutoMapperProfiles
{
    public class PuntoDeInteresProfile : Profile
    {
        public PuntoDeInteresProfile()
        {
            CreateMap<Entities.PuntoDeInteres, Models.PuntoDeInteresDto>();
        }
    }
}

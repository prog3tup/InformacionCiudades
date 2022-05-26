using AutoMapper;
using InformacionCiudades.API.Models;
using InformacionCiudades.API;
using InformacionCiudades.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/ciudades")]
    public class CiudadesController : ControllerBase //controller deriva de ControllerBase
    {
        //private readonly CiudadesData _ciudadesData;
        private readonly IInfoCiudadesRepository _infoCiudadesRepository;
        private readonly IMapper _mapper;

        public CiudadesController(IInfoCiudadesRepository infoCiudadesRepository, IMapper mapper)
        {
            //_ciudadesData = ciudadesData;
            _infoCiudadesRepository = infoCiudadesRepository;
            _mapper = mapper;
        }

        [HttpGet] 
        public ActionResult<IEnumerable<CiudadSinPuntosDeInteresDto>> GetCiudades() //JsonResults implementa IActionResults
        {
            var ciudades = _infoCiudadesRepository.GetCiudades();

            /*var resultados = new List<CiudadSinPuntosDeInteresDto>();

            foreach (var ciudad in ciudades)
            {
                resultados.Add(new CiudadSinPuntosDeInteresDto {
                    Id = ciudad.Id,
                    Descripcion = ciudad.Descripcion,
                    Nombre = ciudad.Nombre
                });
            }*/ //Esto ya no lo usamos porque ahora todo ese trabajo lo hace automapper.

            return Ok(_mapper.Map<IEnumerable<CiudadSinPuntosDeInteresDto>>(ciudades));

            //return Ok(_ciudadesData.Ciudades);
        }

        [HttpGet("{id}")]
        public IActionResult GetCiudad(int id, bool incluirPuntosDeInteres = false)
        {
            var ciudad = _infoCiudadesRepository.GetCiudad(id, incluirPuntosDeInteres);
            if (ciudad == null)
                return NotFound();

            if( incluirPuntosDeInteres)
                return Ok(_mapper.Map<CiudadDto>(ciudad));

            return Ok(_mapper.Map<CiudadSinPuntosDeInteresDto>(ciudad));
        }
    }
}

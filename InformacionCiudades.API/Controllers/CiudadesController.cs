using CityInfo.API.Models;
using InformacionCiudades.API;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/ciudades")]
    public class CiudadesController : ControllerBase //controller deriva de ControllerBase
    {
        private readonly CiudadesData _ciudadesData;

        public CiudadesController(CiudadesData ciudadesData)
        {
            _ciudadesData = ciudadesData;
        }

        [HttpGet] 
        public ActionResult<IEnumerable<CiudadDto>> GetCiudades() //JsonResults implementa IActionResults
        {
            return Ok(_ciudadesData.Ciudades);
        }

        [HttpGet("{id}")] 
        public ActionResult<CiudadDto> GetCiudad(int id)
        {
            var ciudadARetornar = _ciudadesData.Ciudades.FirstOrDefault(x => x.Id == id);
            if (ciudadARetornar == null)
                return NotFound();
            return Ok(ciudadARetornar);
        }
    }
}

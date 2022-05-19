using CityInfo.API.Models;
using InformacionCiudades.API;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/ciudades")]
    public class CiudadesController : ControllerBase //controller deriva de ControllerBase
    {
        /*[HttpGet("JSON")] 
        public JsonResult GetCiudadesJSON()
        {
            return new JsonResult( CiudadesData.InstanciaActual.Ciudades);
        }*/ //Esto lo cambiamos por lo mismo, ahora queremos usar el OkObjectResult de mas abajo.

        [HttpGet] //("api/ciudades") ya no se necesita mas aca pq agregamos el route
        public ActionResult<IEnumerable<CiudadDto>> GetCiudades() //JsonResults implementa IActionResults
        {
            return Ok(CiudadesData.InstanciaActual.Ciudades);
        }

        [HttpGet("{id}")] 
        public ActionResult<CiudadDto> GetCiudad(int id)
        {
            var ciudadARetornar = CiudadesData.InstanciaActual.Ciudades.FirstOrDefault(x => x.Id == id);
            if (ciudadARetornar == null)
                return NotFound();
            return Ok(ciudadARetornar);
        }
    }
}

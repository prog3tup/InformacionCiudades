using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/ciudades")]
    public class CiudadesController : ControllerBase //controller
                                                     //deriva de ControllerBase, usamos ControllerBase para
                                                     //no traer todas las cosas que no vamos a usar
    {
        [HttpGet]
        public JsonResult GetCiudades()
        {
            return new JsonResult(
            new List<object>
            {
                    new { id = 1, name = "Rosario"},
                    new { id = 2, name = "Buenos Aires"}
            });
        }

        [HttpGet("metodo2")]
        public JsonResult GetCiudad()
        {
            return new JsonResult(new List<string>
            {
                "Santa Fe",
                "Funes"
            });
        }
    }
}

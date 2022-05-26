using CityInfo.API.Models;
using InformacionCiudades.API;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/ciudades/{idCiudad}/puntosdeinteres")] //Ya que esto es dependiente de ciudades necesito que primero me indique la ciudad
    public class PuntosDeInteresController : ControllerBase
    {
        private readonly CiudadesData _ciudadesData;

        public PuntosDeInteresController(CiudadesData ciudadesData)
        {
            _ciudadesData = ciudadesData;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PuntoDeInteresDto>> GetPuntosDeInteres(int idCiudad)
        {
            var ciudad = _ciudadesData.Ciudades.FirstOrDefault(x => x.Id == idCiudad);
            if (ciudad == null)
                return NotFound();

            return Ok(ciudad.PuntosDeInteres);
        }

        [HttpGet("{idPuntoDeInteres}", Name = "GetPuntoDeInteres")] // El name se lo da para usarlo en el POST.
        public ActionResult<PuntoDeInteresDto> GetPuntosDeInteres(int idCiudad, int idPuntoDeInteres)
        {
            var city = _ciudadesData.Ciudades.FirstOrDefault(x => x.Id == idCiudad);

            if (city == null)
                return NotFound();

            var pointOfInterest = city.PuntosDeInteres.FirstOrDefault(x => x.Id == idPuntoDeInteres);

            if (pointOfInterest == null)
                return NotFound();
            
            return Ok(pointOfInterest);
        }

        [HttpPost]
        public ActionResult<PuntoDeInteresDto> CrearPuntoDeInteres(int idCiudad, PuntoDeInteresParaCreacionDto puntoDeInteres)
        {
            var ciudad = _ciudadesData.Ciudades.FirstOrDefault(c => c.Id == idCiudad);
            if (ciudad is null)
            {
                return NotFound();
            }

            var idMaximoPuntosDeInteres = _ciudadesData.Ciudades.SelectMany(c => c.PuntosDeInteres).Max(p => p.Id);

            var nuevoPuntoDeInteres = new PuntoDeInteresDto
            {
                Id = ++idMaximoPuntosDeInteres,
                Nombre = puntoDeInteres.Nombre,
                Descripcion = puntoDeInteres.Descripcion
            };

            ciudad.PuntosDeInteres.Add(nuevoPuntoDeInteres);

            return CreatedAtRoute(//CreatedAtRoute es para q devuelva 201, el 200 de post.
                "GetPuntoDeInteres", //El primer parámetro es el Name del endpoint que hace el Get
                new //El segundo los parametros q necesita ese endpoint
                {
                    idCiudad,
                    idPuntoDeInteres = nuevoPuntoDeInteres.Id
                },
                nuevoPuntoDeInteres);//El tercero es el objeto creado. 
        }

        [HttpPut("{idPuntoDeInteres}")]
        public ActionResult ActualizarPuntoDeInteres(int idCiudad, int idPuntoDeInteres, PuntoDeInteresParaUpdateDto pointOfInterest)
        {
            var ciudad = _ciudadesData.Ciudades.FirstOrDefault(c => c.Id == idCiudad);

            if (ciudad == null)
                return NotFound();

            var puntoDeInteresEnLaBase = ciudad.PuntosDeInteres.FirstOrDefault(p => p.Id == idPuntoDeInteres);
            if (puntoDeInteresEnLaBase == null)
                return NotFound();

            puntoDeInteresEnLaBase.Nombre = pointOfInterest.Nombre;
            puntoDeInteresEnLaBase.Descripcion = pointOfInterest.Descripcion;

            return NoContent();
        }


        [HttpDelete("{idPuntoDeInteres}")]
        public ActionResult DeletePointOfInterest(int idCiudad, int idPuntoDeInteres)
        {
            var ciudad = _ciudadesData.Ciudades.FirstOrDefault(c => c.Id == idCiudad);
            if (ciudad is null)
                return NotFound();

            var puntoDeInteresAEliminar = ciudad.PuntosDeInteres
                .FirstOrDefault(p => p.Id == idPuntoDeInteres);
            if (puntoDeInteresAEliminar is null)
                return NotFound();

            ciudad.PuntosDeInteres.Remove(puntoDeInteresAEliminar);

            return NoContent();
        }
    }
}

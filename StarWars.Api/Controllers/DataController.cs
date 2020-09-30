using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// Edited by CPang 2020-07-17 Challenge 3
namespace StarWars.Api.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        [Route("species")]
        public IActionResult GetSpecies()
        {
            var species = System.IO.File.ReadAllText("Data/Species.json");
            return Ok(species);
        }

        [HttpGet]
        [Route("planets")]
        public IActionResult GetPlanets()
        {
            var planets = System.IO.File.ReadAllText("Data/Planets.json");
            return Ok(planets);
        }
    }
}

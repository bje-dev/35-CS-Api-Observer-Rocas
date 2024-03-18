using Api_Rocas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Rocas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RocaController : ControllerBase
    {
        public static Random random = new Random();
        
        [HttpGet]
        [Route("roca")]

        public IActionResult getRoca()
        {

            Roca _roca = default;

            var nombre = new string[] { "ranito", "gabro", "basalto", "obsidiana", "riolita", "gneis", "marmol", "pizarra", "arenisca", "lutita", "caliza", "halita" };
            var tipo = new string[] { "igneas", "metaforicas", "seridianas" };
            var origen = new string[] { "america", "europa", "asia", "oceania" };
            var tamaño = random.Next(10, 100);
            var lugar = new string[] { "oceano", "tierra" };

            _roca = new Roca();

            _roca.Nombre = nombre[random.Next(nombre.Length)];
            _roca.Tipo = tipo[random.Next(tipo.Length)];
            _roca.Origen = origen[random.Next(origen.Length)];
            _roca.Tamaño = tamaño;
            _roca.Lugar = lugar[random.Next(lugar.Length)];



            return Ok(_roca);

        }
        
    }
}

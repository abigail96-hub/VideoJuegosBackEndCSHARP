using Microsoft.AspNetCore.Mvc;
using WebAppVideojuegos.Services;
using WebAppVideojuegos.Models;
using Microsoft.AspNetCore.Http;


namespace WebAppVideojuegos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VideojuegoController : ControllerBase
    {
        private readonly VideojuegoService _videojuegoService;

        public VideojuegoController(VideojuegoService videojuegoService)
        {
            _videojuegoService = videojuegoService;
        }

        [HttpGet]
        public async Task<IActionResult> Videojuegos()
        {
            List<Videojuego> Videojuegos = await _videojuegoService.Videojuegos();

            return StatusCode(StatusCodes.Status200OK, Videojuegos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> VideoJuego(int id)
        {
            Videojuego objeto = await _videojuegoService.VideoJuego(id);
            return StatusCode(StatusCodes.Status200OK, objeto);
        }

        [HttpPost]
        public async Task<IActionResult> CrearVideojuego([FromBody] Videojuego objeto)
        {
            bool respuesta = await _videojuegoService.CrearVideojuego(objeto);
            return StatusCode(StatusCodes.Status200OK, new {isSuccess =  respuesta});
        }


        [HttpPut]
        public async Task<IActionResult> EditarVideojuego([FromBody] Videojuego objeto)
        {
            bool respuesta = await _videojuegoService.EditarVideojuego(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSucces = respuesta });
        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarVideojuego (int id)
        {
            bool respuesta = await _videojuegoService.EliminarVideojuego(id);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebAppVideojuegos.Services;
using WebAppVideojuegos.Models;
using Microsoft.AspNetCore.Http;


namespace WebAppVideojuegos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly GeneroService _generoService;

        public GeneroController(GeneroService generoService)
        {
            _generoService = generoService;
        }

        [HttpGet]
        public async Task<IActionResult> Generos()
        {
            List<Genero> Generos =  await _generoService.Generos();
            return StatusCode(StatusCodes.Status200OK, Generos);
        }
    }
}

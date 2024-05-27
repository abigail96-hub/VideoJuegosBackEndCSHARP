using Microsoft.AspNetCore.Mvc;
using WebAppVideojuegos.Services;
using WebAppVideojuegos.Models;
using Microsoft.AspNetCore.Http;


namespace WebAppVideojuegos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsolaController : ControllerBase
    {
        private readonly ConsolaService _consolaService;

        public ConsolaController(ConsolaService consolaService)
        {
            _consolaService = consolaService;
        }


        [HttpGet]

        public async Task<IActionResult> Consolas()
        {
            List<Consola> Consolas = await _consolaService.Consolas();
            return StatusCode(StatusCodes.Status200OK, Consolas);
        }
    }
}

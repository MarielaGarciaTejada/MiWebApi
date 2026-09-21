using Microsoft.AspNetCore.Mvc;
using MiWebApi.Services;

namespace MiWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class McdController : ControllerBase
    {
        private readonly MathService _mathService;
        private readonly HistorialCalculoService _historialService;

        public McdController(MathService mathService, HistorialCalculoService historialService)
        {
            _mathService = mathService;
            _historialService = historialService;
        }


        // 1. Soporta Blazor: /api/mcd?dividendo=46&divisor=12
        [HttpGet]
        public async Task<IActionResult> GetMcdFromQuery([FromQuery] int dividendo, [FromQuery] int divisor)
        {
            return await ProcesarCalculo(dividendo, divisor);
        }

        // /api/mcd/46/12
        [HttpGet("{dividendo:int}/{divisor:int}")]
        public async Task<IActionResult> GetMcdFromRoute([FromRoute] int dividendo, [FromRoute] int divisor)
        {
            return await ProcesarCalculo(dividendo, divisor);
        }

        private async Task<IActionResult> ProcesarCalculo(int dividendo, int divisor)
        {
            try
            {
                int mcd = _mathService.CalcularMcd(dividendo, divisor);
                await _historialService.RegistrarAsync(dividendo, divisor, mcd);

                return Ok(new
                {
                    dividendo,
                    divisor,
                    mcd
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
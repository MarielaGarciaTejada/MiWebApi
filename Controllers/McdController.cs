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

        [HttpGet]
        public IActionResult GetMcd(int dividendo, int divisor)
        {
            int mcd = _mathService.CalcularMcd(dividendo, divisor);

            return Ok(new
            {
                dividendo,
                divisor,
                mcd
            });
        }

        /*
        [HttpGet]
        public async Task<IActionResult> GetMcd(int dividendo, int divisor)
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
        */

    }
}


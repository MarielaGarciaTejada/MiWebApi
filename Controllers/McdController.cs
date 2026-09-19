using Microsoft.AspNetCore.Mvc;
using MiWebApi.Services;

namespace MiWebApi.Controllers
{
    [ApiController]
   // [Route("api/[controller]")]
public class McdController : ControllerBase
{
    private readonly MathService _mathService;
    private readonly HistorialCalculoService _historialService;

    public McdController (MathService mathService, HistorialCalculoService historialService)
    {
       _mathService = mathService;
       _historialService = historialService;
    }

        [HttpGet]
    public async Task<IActionResult> GetMcd([FromQuery] int dividendo, [FromQuery] int divisor)
        {
            int mcd = _mathService.CalcularMcd(dividendo, divisor);
            await _historialService.RegistrarAsync(dividendo, divisor, mcd);
            return Ok(new
            {
                dividendo = dividendo,
                divisor = divisor,
                mcd = mcd
            });
            
        }
}
}


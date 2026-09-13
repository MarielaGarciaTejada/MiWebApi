using Microsoft.AspNetCore.Mvc;
using MiWebApi.Services;

namespace MiWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
public class McdController : ControllerBase
{
    private readonly MathService _mathService;

    public McdController (MathService mathService)
    {
        _mathService = mathService;
    }

    [HttpGet]
    public IActionResult GetMcd([FromQuery] int dividendo, [FromQuery] int divisor)
        {
            int mcd = _mathService.CalcularMcd(dividendo, divisor);
            return Ok(new
            {
                dividendo = dividendo,
                divisor = divisor,
                mcd = mcd
            });
        }
}
}


using Microsoft.AspNetCore.Mvc;
using StockControl.Communication.Request;
using StockControl.Communication.Response;
using StockControl.Communication.Response.Login;
using StockControl.Domain.Service;

namespace StockControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(JwtTokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(
                [FromBody] LoginRequest loginRequest,
                [FromServices] ILoginService service
            )
        {
            var result = await service.Login(loginRequest);
            return Ok(result);
        }
    }
}

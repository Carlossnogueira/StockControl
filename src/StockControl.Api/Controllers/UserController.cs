using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockControl.Communication.Request.User;
using StockControl.Communication.Response;
using StockControl.Domain.Service;

namespace StockControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> CreateUser(
                [FromBody] CreateUserDto userDto,
                [FromServices] IUserService service
            )
        {
            var result = await service.CreateUserAsync(userDto);
             return Ok("Usuario criado!");
        }
    }
}

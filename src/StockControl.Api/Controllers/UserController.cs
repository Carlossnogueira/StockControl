using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockControl.Communication.Request.User;
using StockControl.Domain.Service;

namespace StockControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateUser(
            [FromBody] CreateUserDto userDto,
            [FromServices] IUserService service
            )
        {
            var result = await service.CreateUserAsync(userDto);

            // remove after create custom exception
            if (result != null)
            {
                return Ok("Usuario criado!");
            }
            else
            {
                return BadRequest();
            }

        }
    }
}

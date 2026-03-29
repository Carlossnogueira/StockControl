using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockControl.Communication.Request.Item;
using StockControl.Communication.Response;
using StockControl.Communication.Response.Item;
using StockControl.Domain.Service;

namespace StockControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [Authorize]
        public async Task<IActionResult> CreateItem(
            [FromBody] CreateItemDto itemDto,
            [FromServices] IItemService itemService
        )
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await itemService.CreateItemAsync(int.Parse(userId!), itemDto);
            return Ok("Item criado");
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CreateItemResponse>), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> GetItems(
            [FromServices] IItemService itemService
        )
        {
            var items = await itemService.GetAllAsync();
            return Ok(items);
        }
    }
}

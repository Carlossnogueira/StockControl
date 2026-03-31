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
        [ProducesResponseType(typeof(SuccessResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [Authorize]
        public async Task<IActionResult> CreateItem(
            [FromBody] CreateItemDto itemDto,
            [FromServices] IItemService itemService
        )
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await itemService.CreateItemAsync(int.Parse(userId!), itemDto);
            return Ok(new SuccessResponse("Item criado cum sucesso!"));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ItemListResponse>), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> GetItems(
            [FromServices] IItemService itemService
        )
        {
            var items = await itemService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ItemListResponse), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> GetById(
            [FromRoute] int id,
            [FromServices] IItemService itemService
        )
        {
            var response = await itemService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpGet("get/{name}")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ItemListResponse), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> GetByName(
          [FromRoute] string name,
          [FromServices] IItemService itemService
      )
        {
            var response = await itemService.GetByNameAsync(name);
            return Ok(response);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ItemListResponse), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateItemDto itemDto,
            [FromServices] IItemService itemService
        )
        {
            var response = await itemService.UpdateItem(id, itemDto);
            return Ok(response);
        }
    }
}


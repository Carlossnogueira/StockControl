using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockControl.Communication.Request.Catogory;
using StockControl.Communication.Request.User;
using StockControl.Communication.Response;
using StockControl.Communication.Response.Category;
using StockControl.Domain.Service;

namespace StockControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [Authorize]
        public async Task<IActionResult> CreateCategory(
               [FromBody] CreateCategoryDto categoryDto,
               [FromServices] ICategoryService categoryService
           )
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await categoryService.CreateCategoryAsync(int.Parse(userId!), categoryDto);
            return Ok("Categoria criada");
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoryResponse>), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> GetCategories(
            [FromServices] ICategoryService categoryService
        )
        {
            var categories = await categoryService.GetAllAsync();
            return Ok(categories);
        }
    }
}

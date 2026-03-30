using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockControl.Communication.Request.Catogory;
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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> GetById(
            [FromRoute] int id,
            [FromServices] ICategoryService categoryService
            )
        {
            var result = await categoryService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] CreateCategoryDto categoryDto,
            [FromServices] ICategoryService categoryService
            )
        {
            var result = await categoryService.Update(id, categoryDto);
            return Ok(result);
        }
    }
}

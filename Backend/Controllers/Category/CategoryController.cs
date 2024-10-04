using Backend.DTO.Category;
using Backend.Services.Category;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Category;

[Route("api/[controller]")]
[ApiController]
public class CategoryController: Controller
{
    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDTO>))]
    public async Task<IActionResult> GetAllCategories()
    {
        IEnumerable<CategoryDTO> categories = await _categoryService.GetAllCategories();
        return Ok(categories);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDTO>))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        CategoryDTO category = await _categoryService.GetCategoryById(id);
        if(category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(CategoryDTO))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> AddCategory([FromBody] CreateCategoryDTO createCategoryDTO)
    {
        try
        {
            CategoryDTO category = await _categoryService.CreateCategory(createCategoryDTO);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }
        catch(ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
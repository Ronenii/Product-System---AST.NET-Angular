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
}
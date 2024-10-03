using Backend.DTO.Category;
using Backend.Interfaces;
using Backend.Services.Category.Validator;

namespace Backend.Services.Category;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly CategoryValidator _categoryValidator;


    public async Task<ICollection<CategoryDTO>> GetAllCategories()
    {
        ICollection<Models.Category> categories = await _categoryRepository.All();

        List<CategoryDTO> categoryDTOs = categories.Select(c => c.ToCategoryDTO()).ToList();

        return categoryDTOs;
    }

    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        Models.Category category = await _categoryRepository.GetById(id);
        
        return category.ToCategoryDTO();
    }

    public async Task<CategoryDTO> CreateCategory(CreateCategoryDTO createCategoryDto)
    {
        await _categoryValidator.Validate(createCategoryDto);

        Models.Category category = new Models.Category { Name = createCategoryDto.Name };
        
        bool success = await _categoryRepository.Add(category);
        if (!success)
        {
            throw new Exception("Failed to create category");
        }

        return category.ToCategoryDTO();
    }
}
using System.Text.RegularExpressions;
using Backend.DTO.Category;
using Backend.Interfaces;
using Backend.Interfaces.Generic.Repository;
using Backend.Services.Generic.Validator;
using ArgumentException = System.ArgumentException;

namespace Backend.Services.Category.Validator;

public class CategoryValidator : GenericValidator<CreateCategoryDTO>
{
    private readonly ICategoryRepository? r_CategoryRepository;
    public CategoryValidator(ICategoryRepository categoryRepository)
    {
        this.r_CategoryRepository = categoryRepository;
    }

    public override async Task Validate(CreateCategoryDTO category)
    {
        await validateName(category.Name);
    }

    private async Task validateName(string name)
    {
        if(await r_CategoryRepository.NameExists(name))
        {
            throw new ArgumentException("Category name already exists");
        }

        if(!isRegexValid(name))
        {
            throw new ArgumentException("Category name cannot be null and must only contain alphabet characters");
        }
    }

    private bool isRegexValid(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            return false;
        }

        Regex regex = new Regex("^[a-zA-Z]+$");

        return regex.IsMatch(name);
    }
}
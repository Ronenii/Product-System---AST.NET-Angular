using System.Text.RegularExpressions;
using Backend.DTO.Category;
using Backend.Interfaces;
using Backend.Interfaces.Generic.Repository;
using Backend.Services.Generic.Validator;
using ArgumentException = System.ArgumentException;

namespace Backend.Services.Category.Validator;

public class CategoryValidator : GenericValidator<CreateCategoryDTO>
{
    public CategoryValidator(IGenericRepository<CreateCategoryDTO> repository)
        : base(repository)
    {
    }

    public override void Validate(CreateCategoryDTO category)
    {
        validateName(category.Name);
    }

    private void validateName(string name)
    {
        if((_repository as ICategoryRepository).NameExists(name).Result)
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
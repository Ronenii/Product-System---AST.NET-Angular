using System.Text.RegularExpressions;
using Backend.DTO.Product;
using Backend.Interfaces;
using Backend.Services.Generic.Validator;

namespace Backend.Services.Product.Validator;

public class ProductValidator: IValidator<CreateProductDTO>
{
    private readonly IProductRepository? r_ProductRepository;
    public ProductValidator(IProductRepository productRepository)
    {
        this.r_ProductRepository = productRepository;
    }

    public async Task Validate(CreateProductDTO product)
    {
        await validateName(product.Name);
        await validatePrice(product.Price);
    }

    private async Task validateName(string name)
    {
        if(await r_ProductRepository.NameExists(name))
        {
            throw new ArgumentException("Product name already exists");
        }

        if(!isProductNameRegexValid(name))
        {
            throw new ArgumentException("Product name cannot be null or contain special characters");
        }
    }

    private async Task validatePrice(decimal price)
    {
        if(price < 0)
        {
            throw new ArgumentException("Price cannot be negative");
        }
    }

    private bool isProductNameRegexValid(string name)
    {
        const string productNameRegex = @"^[a-zA-Z0-9]+$";
        return Regex.IsMatch(name, productNameRegex);
    }
}
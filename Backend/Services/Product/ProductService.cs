using Backend.DTO.Category;
using Backend.DTO.Product;
using Backend.Interfaces;
using Backend.Models.Filter;
using Backend.Services.Product.Validator;

namespace Backend.Services.Product;

public class ProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ProductValidator _productValidator;


    public async Task<ICollection<ProductDTO>> GetAllProducts()
    {
        ICollection<Models.Product> products = await _productRepository.All();

        List<ProductDTO> productDTOs = products.Select(p => p.ToDTO()).ToList();

        return productDTOs;
    }
    
    public async Task<ICollection<ProductDTO>> GetFilteredProducts(ProductFilter filter)
    {
        ICollection<Models.Product> products = await _productRepository.GetFilteredProducts(filter);

        List<ProductDTO> productDTOs = products.Select(p => p.ToDTO()).ToList();

        return productDTOs;
    }

    public async Task<ProductDTO> GetProductById(int id)
    {
        Models.Product product = await _productRepository.GetById(id);
        
        return product.ToDTO();
    }

    public async Task<ProductDTO> CreateProduct(CreateProductDTO createProductDTO)
    {
        await _productValidator.Validate(createProductDTO);
        
        Models.Product product = new Models.Product
                                     {
                                         Name = createProductDTO.Name,
                                         Description = createProductDTO.Description,
                                         CategoryId = createProductDTO.CategoryId,
                                         Stock = createProductDTO.Stock,
                                         Price = createProductDTO.Price
                                     };
        
        bool success = await _productRepository.Add(product);
        if (!success)
        {
            throw new Exception("Failed to create product");
        }

        return product.ToDTO();
    }

    public async Task<int> DeleteProduct(int id)
    {
        bool success = await _productRepository.Delete(id);
        if (!success)
        {
            throw new Exception("Failed to delete product");
        }

        return id;
    }
}
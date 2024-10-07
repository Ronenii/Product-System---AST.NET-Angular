using Backend.DTO.Category;
using Backend.DTO.Product;
using Backend.Models.Filter;
using Backend.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Product;

[Route("api/[controller]")]
[ApiController]
public class ProductController: Controller
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    [Authorize(policy: "AnyUser")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ProductDTO>))]
    public async Task<IActionResult> GetAllProducts()
    {
        IEnumerable<ProductDTO> products = await _productService.GetAllProducts();
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    [Authorize(policy: "AnyUser")]
    [ProducesResponseType(200, Type = typeof(ProductDTO))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetProductById(int id)
    {
        ProductDTO product = await _productService.GetProductById(id);
        if(product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    [Authorize(policy: "AdminOnly")]
    [ProducesResponseType(201, Type = typeof(ProductDTO))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> AddProduct([FromBody] CreateProductDTO createProductDTO)
    {
        try
        {
            ProductDTO product = await _productService.CreateProduct(createProductDTO);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        catch(ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPost("Filter")]
    [Authorize(policy: "AnyUser")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ProductDTO>))]
    public async Task<IActionResult> GetFilteredProducts([FromBody] ProductFilterDTO productFilterDTO)
    {
        IEnumerable<ProductDTO> product = await _productService.GetFilteredProducts(productFilterDTO);

        return Ok(product);
    }

    [HttpDelete("{id}")]
    [Authorize(policy: "AdminOnly")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        int deleted = await _productService.DeleteProduct(id);
        return Ok(new { message = $"Product with id {deleted} was deleted." });
    }
    
}
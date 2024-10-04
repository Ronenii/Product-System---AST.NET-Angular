using Backend.DTO.Category;
using Backend.DTO.Product;
using Backend.Services.Product;
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
    [ProducesResponseType(200, Type = typeof(IEnumerable<ProductDTO>))]
    public async Task<IActionResult> GetAllProducts()
    {
        IEnumerable<ProductDTO> products = await _productService.GetAllProducts();
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ProductDTO>))]
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
}
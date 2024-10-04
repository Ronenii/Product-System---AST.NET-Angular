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
}
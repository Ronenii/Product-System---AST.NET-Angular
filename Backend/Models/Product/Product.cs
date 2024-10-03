using Backend.DTO.Product;

namespace Backend.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }

    public ProductDTO ToDTO()
    {
        return new ProductDTO(Id, Name, Description, Price, Stock, CategoryId);
    }
}
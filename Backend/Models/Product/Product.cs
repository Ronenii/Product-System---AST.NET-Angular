using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.DTO.Product;

namespace Backend.Models;

public class Product
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    [Column("price")]
    [Required]
    public decimal Price { get; set; }
    
    [Column("stock")]
    [Required]
    public int Stock { get; set; }
    
    [Column("category_id")]
    [Required]
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }

    public ProductDTO ToDTO()
    {
        return new ProductDTO(Id, Name, Description, Price, Stock, CategoryId);
    }
}
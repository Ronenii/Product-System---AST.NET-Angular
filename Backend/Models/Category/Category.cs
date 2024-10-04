using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.DTO.Category;

namespace Backend.Models;

public class Category
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();

    public CategoryDTO ToDTO()
    {
        return new CategoryDTO(Id, Name);
    }
}
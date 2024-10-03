using Backend.DTO.Category;

namespace Backend.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();

    public CategoryDTO ToDTO()
    {
        return new CategoryDTO(Id, Name);
    }
}
namespace Backend.Models.Filter;

public class ProductFilterDTO
{
    public int? MinStock { get; }
    public int? MaxStock { get; }
    public decimal? MinPrice { get; }
    public decimal? MaxPrice { get; }
    public string Category { get; }
}
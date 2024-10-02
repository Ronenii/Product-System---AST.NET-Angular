namespace Backend.Models.Filter;

public class ProductFilter
{
    public int? MinStock { get; set; }
    public int? MaxStock { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string Category { get; set; }
}
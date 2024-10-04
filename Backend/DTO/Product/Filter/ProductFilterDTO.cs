namespace Backend.Models.Filter;

public record ProductFilterDTO(int? MinStock, int? MaxStock, decimal? MinPrice, decimal? MaxPrice, int? CategoryId);
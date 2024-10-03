namespace Backend.DTO.Product;

public record CreateProductDTO(string Name, string Description, decimal Price, int Stock, int CategoryId);
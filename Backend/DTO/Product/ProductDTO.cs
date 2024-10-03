namespace Backend.DTO.Product;

public record ProductDTO(int Id, string Name, string Description, decimal Price, int Stock, int CategoryId);
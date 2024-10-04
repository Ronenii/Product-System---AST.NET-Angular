namespace Backend.DTO.User;

public record CreateUserDTO(string Username, string Password, bool IsAdmin);
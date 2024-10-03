using Backend.DTO.User;

namespace Backend.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string PasswordHash  { get; set; }
    public bool IsAdmin { get; set; }

    public UserDTO ToUserDTO()
    {
        return new UserDTO(Id, Username, Email, IsAdmin);
    }
}
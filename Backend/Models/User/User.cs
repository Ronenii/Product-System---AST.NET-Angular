using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.DTO.User;

namespace Backend.Models;

[Table("Users")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("username")]
    [Required]
    [MaxLength(255)]
    public string Username { get; set; }
    
    [Column("password_hash")]
    [Required]
    [MaxLength(255)]
    public string PasswordHash  { get; set; }
    
    [Column("is_admin")]
    [Required]
    public bool IsAdmin { get; set; }

    public UserDTO ToDTO()
    {
        return new UserDTO(Id, Username, IsAdmin);
    }
}
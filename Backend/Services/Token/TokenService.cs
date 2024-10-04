using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services.Token;

public class TokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Models.User user)
    {
        // Define claims for the token (can include more claims if needed)
        List<Claim> claims = new List<Claim>
                                 {
                                     new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                                     new Claim(ClaimTypes.Name, user.Username),
                                     new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User"),
                                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                                 };

        // Create the signing key using the secret from configuration
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Define the token's expiration
        DateTime expires = DateTime.Now.AddMinutes(30);  // Token valid for 30 minutes

        // Create the token
        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: creds);

        // Return the token as a string
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
using System.Text.RegularExpressions;
using Backend.DTO.User;
using Backend.Interfaces;
using Backend.Interfaces.Generic.Repository;
using Backend.Services.Generic.Validator;

namespace Backend.Services.User.Validator;

public class UserValidator: GenericValidator<CreateUserDTO>
{
    private readonly IUserRepository? r_UserRepository;
    public UserValidator(IUserRepository userRepository)
    {
        this.r_UserRepository = userRepository;
    }

    public override async Task Validate(CreateUserDTO user)
    {
        await validateUsername(user.Username);
    }

    private async Task validateUsername(string username)
    {
        if(await r_UserRepository.UsernameExists(username))
        {
            throw new ArgumentException("Username already exists");
        }

        if(!isUsernameRegexValid(username))
        {
            throw new ArgumentException("Username cannot be null and must not contain special characters");
        }
    }

    private bool isUsernameRegexValid(string username)
    {
        if(string.IsNullOrWhiteSpace(username))
        {
            return false;
        }
        
        const string usernameRegex = @"^[a-zA-Z0-9]+$";
        return Regex.IsMatch(username, usernameRegex);
    }
}
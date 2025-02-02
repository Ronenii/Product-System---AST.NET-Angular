﻿using System.Security.Cryptography;
using System.Text;
using Backend.DTO.User;
using Backend.DTO.User.Login;
using Backend.Interfaces;
using Backend.Services.User.Validator;

namespace Backend.Services.User;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserValidator _userValidator;

    public UserService(IUserRepository userRepository, UserValidator userValidator)
    {
        _userRepository = userRepository;
        _userValidator = userValidator;
    }
    
    public async Task<ICollection<UserDTO>> GetAllUsers()
    {
        ICollection<Models.User> users = await _userRepository.All();

        List<UserDTO> userDTOs = users.Select(u => u.ToDTO()).ToList();

        return userDTOs;
    }

    public async Task<UserDTO?> GetUserById(int id)
    {
        Models.User? user = await _userRepository.GetById(id);
    
        return user == null ? null : user.ToDTO();
    }
    
    public async Task<UserDTO> CreateUser(CreateUserDTO createUserDTO)
    {
        await _userValidator.Validate(createUserDTO);

        Models.User user = new Models.User
                               {
                                   Username = createUserDTO.Username,
                                   PasswordHash = hashPassword(createUserDTO.Password),
                                   IsAdmin = createUserDTO.IsAdmin
                               };
        
        bool success = await _userRepository.Add(user);
        if (!success)
        {
            throw new Exception("Failed to create user");
        }

        return user.ToDTO();
    }

    // This method converts the password into a byte array and then computes the SHA256 hash of the password.
    // The resulting hash (which is a byte array) is converted into a Base64 string for storage in the database.
    private string hashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            return Convert.ToBase64String(hashBytes);
        }
    }

    public async Task<Models.User> Authenticate(LoginDTO loginDTO)
    {
        Models.User user = await _userRepository.GetByUsername(loginDTO.Username);

        if(user == null)
        {
            return null;
        }

        if(!verifyPassword(loginDTO.Password, user.PasswordHash))
        {
            return null;
        }

        return user;
    }

    private bool verifyPassword(string enteredPassword, string storedPasswordHash)
    {
        string enteredPasswordHash = hashPassword(enteredPassword);

        return enteredPasswordHash == storedPasswordHash;
    }
}
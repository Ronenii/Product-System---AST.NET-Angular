using Backend.DTO.User;
using Backend.Interfaces.Generic.Repository;
using Backend.Services.Generic.Validator;

namespace Backend.Services.User.Validator;

public class UserValidator: GenericValidator<CreateUserDTO>
{
    public UserValidator(IGenericRepository<CreateUserDTO> repository)
        : base(repository)
    {
    }

    public override void Validate(CreateUserDTO user)
    {
        
    }

    private void validateEmail(string email)
    {
        
    }
    
    private void validate
}
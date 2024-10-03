namespace Backend.Services.Generic.Validator;

public interface IValidator<T>
{
    void Validate(T value);
}
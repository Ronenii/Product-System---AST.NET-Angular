namespace Backend.Services.Generic.Validator;

public interface IValidator<T>
{
    Task Validate(T value);
}
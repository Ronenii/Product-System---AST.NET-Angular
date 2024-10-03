using Backend.Interfaces.Generic.Repository;

namespace Backend.Services.Generic.Validator;

public abstract class GenericValidator<T> : IValidator<T>
    where T : class
{
    public abstract Task Validate(T value);
}
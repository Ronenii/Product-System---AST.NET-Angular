using Backend.Interfaces.Generic.Repository;

namespace Backend.Services.Generic.Validator;

public abstract class GenericValidator<T> : IValidator<T>
    where T : class
{
    protected IGenericRepository<T> _repository;
    protected GenericValidator(IGenericRepository<T> repository)
    {
        this._repository = repository;
    }

    public abstract void Validate(T value);
}
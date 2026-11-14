namespace EmployeeAPI.Services;

public class SecondaryOperationService
{
    public ITransientOperation Transient { get; }
    public IScopedOperation Scoped { get; }
    public ISingletonOperation Singleton { get; }

    public SecondaryOperationService(
        ITransientOperation transient,
        IScopedOperation scoped,
        ISingletonOperation singleton)
    {
        Transient = transient;
        Scoped = scoped;
        Singleton = singleton;
    }
}
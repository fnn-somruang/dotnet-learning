namespace EmployeeAPI.Services;

public class OperationService : ITransientOperation, IScopedOperation, ISingletonOperation
{
    public Guid OperationId { get; }

    public OperationService()
    {
        OperationId = Guid.NewGuid();
    }
}
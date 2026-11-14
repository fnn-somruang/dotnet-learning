namespace EmployeeAPI.Services;

public interface IOperationService
{
    Guid OperationId { get; }
}

public interface ITransientOperation : IOperationService { }
public interface IScopedOperation : IOperationService { }
public interface ISingletonOperation : IOperationService { }
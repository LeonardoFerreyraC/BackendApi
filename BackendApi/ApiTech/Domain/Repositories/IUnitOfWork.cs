namespace BackendApi.Shared.Persistence.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}
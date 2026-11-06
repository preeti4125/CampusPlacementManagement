namespace CampusPlacementManagement.Core.Interfaces.Repositories;
public interface IUnitOfWork : IDisposable
{
    Task<int> CompleteAsync();
}

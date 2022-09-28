using WebAPIStarter.Models;
using WebAPIStarter.Repository;

namespace WebAPIStarter.IRepository;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Sample> Samples { get; }

    Task Save();
}
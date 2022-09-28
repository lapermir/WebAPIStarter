using WebAPIStarter.Data;
using WebAPIStarter.IRepository;
using WebAPIStarter.Models;

namespace WebAPIStarter.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private GenericRepository<Sample> _samples;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public IGenericRepository<Sample> Samples => _samples ??= new GenericRepository<Sample>(_context);

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
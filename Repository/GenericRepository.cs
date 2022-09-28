using Microsoft.EntityFrameworkCore;
using WebAPIStarter.Data;
using WebAPIStarter.IRepository;

namespace WebAPIStarter.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _db;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _db = _context.Set<T>();
    }
    /// <summary>
    /// It will Delete an entity based on given id.
    /// </summary>
    /// <param name="id">int id</param>
    /// <returns></returns>
    public async Task Delete(int id)
    {
        // Get the entity with Id
        var entity = await _db.FindAsync(id);
        // Remove it
        _db.Remove(entity);
    }

    /// <summary>
    /// It will Delete range of entities.
    /// </summary>
    /// <param name="entities">IEnumerable<T> entities</param>
    public void DeleteRange(IEnumerable<T> entities)
    {
        _db.RemoveRange(entities);
    }

    /// <summary>
    /// Returns the entity.
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    public async Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> expression = null, List<string> includes = null)
    {
        IQueryable<T> query = _db;

        // Includes
        if (includes != null)
        {
            foreach (var i in includes)
            {
                query = query.Include(i);
            }
        }

        return await query.AsNoTracking().FirstOrDefaultAsync(expression);
    }

    /// <summary>
    /// Returns list of entities.
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="orderBy"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    public async Task<List<T>> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
    {
        IQueryable<T> query = _db;

        // Apply expression.
        if (expression != null)
        {
            query = query.Where(expression);
        }

        // Apply includes.
        if (includes != null)
        {
            foreach (var i in includes)
            {
                query = query.Include(i);
            }
        }

        // Apply order by.
        if (orderBy != null)
        {
            query = orderBy(query);
        }

        return await query.AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// Insert the given entity to the database.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task Insert(T entity)
    {
        await _db.AddAsync(entity);
    }

    /// <summary>
    /// Insert a range of entities to the database.
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public async Task InsertRange(IEnumerable<T> entities)
    {
        await _db.AddRangeAsync(entities);
    }

    /// <summary>
    /// Updates the given entity
    /// </summary>
    /// <param name="entity"></param>
    public void Update(T entity)
    {
        _db.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}
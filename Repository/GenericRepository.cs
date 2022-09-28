using WebAPIStarter.IRepository;

namespace WebAPIStarter.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    /// <summary>
    /// It will Delete an entity based on given id.
    /// </summary>
    /// <param name="id">int id</param>
    /// <returns></returns>
    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// It will Delete range of entities.
    /// </summary>
    /// <param name="entities">IEnumerable<T> entities</param>
    public void DeleteRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns the entity.
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    public Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> expression = null, List<string> includes = null)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns list of entities.
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="orderBy"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    public Task<List<T>> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Insert the given entity to the database.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task Insert(T entity)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Insert a range of entities to the database.
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public Task InsertRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates the given entity
    /// </summary>
    /// <param name="entity"></param>
    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
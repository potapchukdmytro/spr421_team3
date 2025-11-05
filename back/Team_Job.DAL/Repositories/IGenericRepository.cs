using Team_Job.DAL.Entities;

namespace Team_Job.DAL.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(params TEntity[] entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(string id);
        IQueryable<TEntity> GetAll();
    }
}

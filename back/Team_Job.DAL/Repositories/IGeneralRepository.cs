namespace Team_Job.DAL.Repositories
{
    public interface IGeneralRepository<TEntity>
        where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(params TEntity[] entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        IQueryable<TEntity> GetAll();
    }
}

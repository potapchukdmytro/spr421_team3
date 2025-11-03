
using Microsoft.EntityFrameworkCore;

namespace Team_Job.DAL.Repositories
{
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity>
        where TEntity : class
    {
        private readonly AppDbContext _context;

        public GeneralRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                await _context.Set<TEntity>().AddAsync(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public  IQueryable<TEntity> GetAll()
        {
            return _context
                .Set<TEntity>()
                .AsNoTracking();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

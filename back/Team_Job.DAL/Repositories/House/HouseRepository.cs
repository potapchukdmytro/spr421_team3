using Microsoft.EntityFrameworkCore;
using Team_Job.DAL.Entities;

namespace Team_Job.DAL.Repositories.House
{
    public class HouseRepository :
             GenericRepository<HouseEntity>, IHouseRepository
    {
        public HouseRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<HouseEntity> Houses => GetAll();

        public IQueryable<HouseEntity>? GetByAddress(string adress)
        {
            return Houses
                
                .Where(e => e.Address.ToLower() == adress.ToLower());
        }

        public IQueryable<HouseEntity>? GetByHouseUser(string Gmail)
        {
            return Houses
                .Include(d=>d.Owner)
                .Where(e => e.Owner.Email.ToLower() == Gmail.ToLower());
        }


    }
}

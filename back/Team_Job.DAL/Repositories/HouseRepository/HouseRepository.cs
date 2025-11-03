using Team_Job.DAL.Entities;

namespace Team_Job.DAL.Repositories.HouseRepository
{
    public class HouseRepository
        : GeneralRepository<HouseEntity>, IHouseRepository
    {
        public HouseRepository(AppDbContext context) : base(context){}
    }
}

using Team_Job.DAL.Entities;

namespace Team_Job.DAL.Repositories.House
{
    public interface IHouseRepository :
        IGenericRepository<HouseEntity>
    {
        IQueryable<HouseEntity> Houses { get; }

        IQueryable<HouseEntity>? GetByAddress(string adress);

        IQueryable<HouseEntity>? GetByHouseUser(string Gmail);
    }
}

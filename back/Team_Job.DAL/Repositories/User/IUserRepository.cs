using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Job.DAL.Entities;

namespace Team_Job.DAL.Repositories.User
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        public IQueryable<UserEntity> Users { get; }

        Task<UserEntity?> GetByEmailAsync(string email);

        Task<UserEntity?> GetWithBookingsAsync(string userId);

        Task<UserEntity?> GetWithHousesAsync(string userId);
    }
}

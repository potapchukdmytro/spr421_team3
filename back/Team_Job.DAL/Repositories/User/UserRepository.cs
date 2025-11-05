using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Job.DAL.Entities;

namespace Team_Job.DAL.Repositories.User
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<UserEntity> Users => GetAll();
        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserEntity?> GetWithBookingsAsync(string userId)
        {
            return await Users
                .Include(u => u.Bookings)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<UserEntity?> GetWithHousesAsync(string userId)
        {
            return await Users
                .Include(u => u.Houses)
                .FirstOrDefaultAsync(u => u.Id == userId);

        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Team_Job.DAL
{
    public class AppDbContext :DbContext
    {
        public  AppDbContext(DbContextOptions options) : base(options) { }
    }
}

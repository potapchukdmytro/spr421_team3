using Microsoft.EntityFrameworkCore;
using Team_Job.DAL.Entities;

namespace Team_Job.DAL
{
    public class AppDbContext :DbContext
    {
        public  AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<HouseEntity> Houses { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookingEntity>()
                .HasOne(b => b.House)
                .WithMany(h => h.Bookings)
                .HasForeignKey(b => b.HouseId);


            modelBuilder.Entity<BookingEntity>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

           modelBuilder.Entity<HouseEntity>()
                .HasOne(h => h.Owner)
                .WithMany(u => u.Houses)
                .HasForeignKey(h => h.OwnerId);
        }
    }
}

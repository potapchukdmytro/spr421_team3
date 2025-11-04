
using Microsoft.EntityFrameworkCore;
using Team_Job.DAL.Entities;

namespace Team_Job.DAL.Repositories.Booking
{
    public class BookingRepository :
        GenericRepository<BookingEntity>, IBookingRepository
    {
        public BookingRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<BookingEntity> Bookings => GetAll();



        public  IQueryable<BookingEntity>? GetByIdUser(string idUser)
        {
            return Bookings
                 .Include(b => b.House)
                 .Include(b => b.User)
                         .Where(b => b.UserId == idUser);
                        
        }

        public  IQueryable<BookingEntity>? GetByHouseAddress(string AddressHouse)
        {
            return  Bookings
                 .Include(b => b.House)
                 .Include(b => b.User)
                .Where(b => b.House.Address == AddressHouse);
        }

        public IQueryable<BookingEntity>? GetByHouseRoomCount(int AmountOfRooms)
        {
            return Bookings
                 .Include(b => b.House)
                 .Include(b => b.User)
                .Where(b => b.House.AmountOfRooms == AmountOfRooms);
        }
    }
}

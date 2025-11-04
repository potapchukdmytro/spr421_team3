using Team_Job.DAL.Entities;

namespace Team_Job.DAL.Repositories.Booking
{
    public interface IBookingRepository
        : IGenericRepository<BookingEntity>
    {
        IQueryable<BookingEntity> Bookings { get; }
        IQueryable<BookingEntity>? GetByHouseRoomCount(int AmountOfRooms);
        IQueryable<BookingEntity>? GetByHouseAddress(string AddressHouse);
        IQueryable<BookingEntity>? GetByIdUser(string idUser);






    }
}

using Team_Job.DAL.Entities;

namespace Team_Job.DAL.Repositories.BookingRepository
{
    public class BookingRepository
        : GeneralRepository<BookingEntity>, IBookingRepository
    {
        public BookingRepository(AppDbContext context) : base(context){}
    }
}

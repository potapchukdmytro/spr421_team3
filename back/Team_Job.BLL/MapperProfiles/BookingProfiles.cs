using AutoMapper;
using Team_Job.BLL.Dtos.Booking;
using Team_Job.DAL.Entities;

namespace Team_Job.BLL.MapperProfiles
{
    public class BookingProfiles : Profile
    {
        public BookingProfiles()
        {
            CreateMap<CreateBookingDto, BookingEntity>();
            CreateMap<BookingEntity, BookingDto>();
        }
    }
}

using Team_Job.BLL.Dtos.Booking;

namespace Team_Job.BLL.Services.Booking
{
    public interface IBookingServices
    {
        Task<ServiceResponse> CreateBookingAsync(CreateBookingDto createBookingDto);

        Task<ServiceResponse> UpdateBookingAsync(UpdateBookingDto updateBookingDto);

        Task<ServiceResponse> DeleteBookingAsync(string id);

        Task<ServiceResponse> GetByIdAsync(string id);

        Task<ServiceResponse> GetAllAsync();

       




    }
}

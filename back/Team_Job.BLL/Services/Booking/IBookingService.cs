using Team_Job.BLL.Dtos.Booking;

namespace Team_Job.BLL.Services.Booking
{
    public interface IBookingService
    {
        Task<ServiceResponse> CreateBookingAsync(CreateBookingDto createBookingDto);

        Task<ServiceResponse> UpdateBookingAsync(UpdateBookingDto updateBookingDto);

        Task<ServiceResponse> DeleteBookingAsync(string id);

        Task<ServiceResponse> GetByIdAsync(string id);

        Task<ServiceResponse> GetAllAsync();

        Task<ServiceResponse> ReserveAsync(CreateBookingDto createBookingDto);

        Task<ServiceResponse> FilterBookingsAsync(
            string? userId = null,
            string? houseId = null,
            DateTime? from = null,
            DateTime? to = null
            );





    }
}

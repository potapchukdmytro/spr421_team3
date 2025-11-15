using Microsoft.AspNetCore.Mvc;
using Team_Job.BLL.Dtos.Booking;
using Team_Job.BLL.Dtos.House;
using Team_Job.BLL.Services.Booking;
using Team_Job.Extensions;

namespace Team_Job.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _BookingService;

        public BookingController(IBookingService bookingService)
        {
            _BookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateBookingDto dto)
        {
            var response = await _BookingService.CreateBookingAsync(dto);
            return this.ToActionResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateBookingDto dto)
        {
            var response = await _BookingService.UpdateBookingAsync(dto);
            return this.ToActionResult(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] string id)
        {
            var response = await _BookingService.DeleteBookingAsync(id);
            return this.ToActionResult(response);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] string id)
        {
            var response = await _BookingService.GetByIdAsync(id);
            return this.ToActionResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _BookingService.GetAllAsync();
            return this.ToActionResult(response);
        }


        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveAsync([FromBody] CreateBookingDto dto)
        {
            var response = await _BookingService.ReserveAsync(dto);
            return this.ToActionResult(response);
        }


        [HttpGet("filter")]
        public async Task<IActionResult> FilterAsync([FromQuery] string? userId, [FromQuery] string? houseId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            var response = await _BookingService.FilterBookingsAsync(userId, houseId, from, to);
            return this.ToActionResult(response);
        }

    }
}

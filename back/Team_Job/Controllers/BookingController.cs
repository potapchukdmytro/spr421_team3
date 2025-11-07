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
        private readonly IBookingServices _BookingServices;

        public BookingController(IBookingServices bookingServices)
        {
            _BookingServices = bookingServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBookingDto dto)
        {
            var response = await _BookingServices.CreateBookingAsync(dto);
            return this.ToActionResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateBookingDto dto)
        {
            var response = await _BookingServices.UpdateBookingAsync(dto);
            return this.ToActionResult(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] string id)
        {
            var response = await _BookingServices.DeleteBookingAsync(id);
            return this.ToActionResult(response);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] string id)
        {
            var response = await _BookingServices.GetByIdAsync(id);
            return this.ToActionResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _BookingServices.GetAllAsync();
            return this.ToActionResult(response);
        }
    }
}

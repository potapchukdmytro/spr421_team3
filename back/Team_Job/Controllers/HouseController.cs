using Microsoft.AspNetCore.Mvc;
using Team_Job.BLL.Dtos.House;
using Team_Job.BLL.Services.House;
using Team_Job.Extensions;
namespace Team_Job.Controllers
{
    [ApiController]
    [Route("api/house")]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _HouseServices;

        public HouseController(IHouseService bookingServices)
        {
            _HouseServices = bookingServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateHouseDto dto)
        {
            var response = await _HouseServices.CreateAsync(dto);
            return this.ToActionResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateHouseDto dto)
        {
            var response = await _HouseServices.UpdateAsync(dto);
            return this.ToActionResult(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] string id)
        {
            var response = await _HouseServices.DeleteAsync(id);
            return this.ToActionResult(response);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] string id)
        {
            var response = await _HouseServices.GetByIdAsync(id);
            return this.ToActionResult(response);
        }

        [HttpGet("by-name")]
        public async Task<IActionResult> GetByNameAsync([FromQuery] string name)
        {


            var response = await _HouseServices.GetByNameAsync(name);
            return this.ToActionResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _HouseServices.GetAllAsync();
            return this.ToActionResult(response);
        }
    }
}

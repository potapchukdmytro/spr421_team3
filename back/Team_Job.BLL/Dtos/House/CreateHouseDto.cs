using Microsoft.AspNetCore.Http;
namespace Team_Job.BLL.Dtos.House
{
    public class CreateHouseDto
    {
        public required string Address { get; set; }
        public int AmountOfRooms { get; set; }
        public decimal PricePerNight { get; set; }

        public IFormFile? PosterFile { get; set; }
        public bool IsAvialable { get; set; } = true;
        public required string OwnerId { get; set; }
    }
}



namespace Team_Job.BLL.Dtos.Booking
{
    public class BookingDto
    {
        public string HouseId { get; set; }
        public string UserId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice { get; set; }

    }
}

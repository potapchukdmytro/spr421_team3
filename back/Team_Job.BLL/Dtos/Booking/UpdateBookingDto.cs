using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Job.BLL.Dtos.Booking
{
    public class UpdateBookingDto
    {
        public string Id { get; set; }
        public string HouseId { get; set; }
        public string UserId { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

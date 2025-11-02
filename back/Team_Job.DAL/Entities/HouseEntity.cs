using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Job.DAL.Entities
{
    public class HouseEntity
    {
        public int HouseId { get; set; }
        public string Address { get; set; }
        public int AmountOfRooms { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvialable { get; set; }
        public List<BookingEntity>? Bookings { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Job.DAL.Entities
{
    public class HouseEntity : BaseEntity
    {
        
        public required string Address { get; set; }
        public int AmountOfRooms { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvialable { get; set; }
        public List<BookingEntity>? Bookings { get; set; }

        public required UserEntity? Owner { get; set; }

        public required string OwnerId { get; set; }

    }
}

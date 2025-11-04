using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Job.DAL.Entities
{
    public class BookingEntity : BaseEntity
    {
        
        public required string HouseId { get; set; }
        public required HouseEntity House { get; set; }
        public required string UserId { get; set; }
        public required UserEntity User { get; set; }

        
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

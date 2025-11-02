using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Job.DAL.Entities
{
    public class BookingEntity
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public HouseEntity? House { get; set; }
        public int UserId { get; set; }
        public UserEntity? User { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

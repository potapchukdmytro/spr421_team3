using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Job.DAL.Entities
{
    public class UserEntity : BaseEntity
    {
        
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public required string Password { get; set; }
        public required string Role { get; set; }

        public List<BookingEntity>? Bookings { get; set; }



        public  IQueryable<HouseEntity> ?Houses { get; set; }
    }
}

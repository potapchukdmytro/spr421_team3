using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Job.BLL.Dtos.House
{
    public class UpdateHouseDto
    {
        public string Id { get; set; }

        public required string Address { get; set; }
        public int AmountOfRooms { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvialable { get; set; } = true;
        public required string OwnerId { get; set; }


    }
}

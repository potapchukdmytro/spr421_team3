namespace Team_Job.BLL.Dtos.House
{
    public class HouseDto
    {
        private bool isAvialable;
        public string? Id { get; set; }
        public string? Address { get; set; }
        public int AmountOfRooms { get; set; }
        public decimal PricePerNight { get; set; }
        public string? PosterUrl { get; set; }
        public bool IsAvialable { get => isAvialable; set => isAvialable = value; }
        public string? OwnerId { get; set; }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Team_Job.DAL.Entities;
using Team_Job.DAL.Entities.Identity;
using Team_Job.DAL.Repositories.Booking;
using Team_Job.DAL.Repositories.House;
using Team_Job.DAL.Repositories.User;
using Team_Job.DAL.Settings;

namespace Team_Job.DAL.Initializer
{
    public static class DbSeeder
    {
        public static async void Seed(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            var repositoryHouse = scope.ServiceProvider.GetRequiredService<IHouseRepository>();
            var repositoryBooking = scope.ServiceProvider.GetRequiredService<IBookingRepository>();
            var repositoryUser = scope.ServiceProvider.GetRequiredService<IUserRepository>();

            var c = repositoryUser.Users.Count() - 1;
            if (repositoryUser.Users.Count() <= 0)
            {
                var user1 = new UserEntity
                {
                    Name = "Ivan",
                    Surname = "Petrenko",
                    Email = "ivan.petrenko@example.com",
                    Password = "IvanPass123",
                    Role = "User"
                };

                var user2 = new UserEntity
                {
                    Name = "Olena",
                    Surname = "Koval",
                    Email = "olena.koval@example.com",
                    Password = "OlenaPass456",
                    Role = "Admin"
                };

                var user3 = new UserEntity
                {
                    Name = "Bohdan",
                    Surname = "Tkach",
                    Email = "bohdan.tkach@example.com",
                    Password = "BohdanPass789",
                    Role = "Moderator"
                };

                await repositoryUser.CreateRangeAsync(user1,user2,user3);

                var house1 = new HouseEntity
                {
                    Address = "вул. Сонячна, 12",
                    AmountOfRooms = 3,
                    PricePerNight = 1200.50m,
                    IsAvialable = true,
                    PosterUrl = "https://example.com/posters/house1.jpg",
                    Bookings = new List<BookingEntity>(),
                    Owner = user1,
                    OwnerId = user1.Id
                };

                var house2 = new HouseEntity
                {
                    Address = "просп. Миру, 45",
                    AmountOfRooms = 2,
                    PricePerNight = 950m,
                    IsAvialable = false,
                    PosterUrl = "https://example.com/posters/house2.jpg",
                    Bookings = new List<BookingEntity>(),
                    Owner = user2,
                    OwnerId = user2.Id
                };

                var house3 = new HouseEntity
                {
                    Address = "вул. Лісова, 7",
                    AmountOfRooms = 5,
                    PricePerNight = 2500m,
                    IsAvialable = true,
                    PosterUrl = "https://example.com/posters/house3.jpg",
                    Bookings = null,
                    Owner = user3,
                    OwnerId = user3.Id
                };

                await repositoryHouse.CreateRangeAsync(house1, house2, house3);

                var booking1 = new BookingEntity
                {
                    HouseId = house1.Id,
                    House =house1,

                    UserId = user1.Id,
                    User = user1,

                    EndDate = DateTime.UtcNow.AddDays(80),
                    TotalPrice = 3600m
                };

                var booking2 = new BookingEntity
                {
                    HouseId = house2.Id,
                    House = house2,

                    UserId = user2.Id,
                    User = user2,

                    EndDate = DateTime.UtcNow.AddDays(100),
                    TotalPrice = 7000m
                };

                var booking3 = new BookingEntity
                {
                    HouseId = house3.Id,
                    House = house3,

                    UserId = user3.Id,
                    User = user3,

                    EndDate = DateTime.UtcNow.AddDays(1),
                    TotalPrice = 2500m
                };
                await repositoryBooking.CreateRangeAsync(booking1, booking2, booking3);
            }
            if (!roleManager.Roles.Any())
            {
                var roleAdmin = new ApplicationRole { Name = RoleSettings.RoleAdmin };
                var roleUser = new ApplicationRole { Name = RoleSettings.RoleUser };

                await roleManager.CreateAsync(roleAdmin);
                await roleManager.CreateAsync(roleUser);
            }

            if (!userManager.Users.Any())
            {
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.com",
                    UserName = "admin",
                    EmailConfirmed = true,
                    FirstName = "Kaplia"
                };

                var user = new ApplicationUser
                {
                    Email = "user@mail.com",
                    UserName = "user",
                    EmailConfirmed = true,
                    FirstName = "Keglia",
                    LastName = "Lampa"
                };

                await userManager.CreateAsync(admin, "gudzy1213");
                await userManager.CreateAsync(user, "gudzy1213");

                await userManager.AddToRolesAsync(admin, [RoleSettings.RoleAdmin, RoleSettings.RoleUser]);
                await userManager.AddToRoleAsync(user, RoleSettings.RoleUser);
            }
        }
    }
}

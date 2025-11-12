
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Team_Job.BLL.Services.House;
using Team_Job.BLL.Services.Storage;
using Team_Job.DAL;
using Team_Job.DAL.Entities.Identity;
using Team_Job.DAL.Initializer;
using Team_Job.DAL.Repositories.Booking;
using Team_Job.DAL.Repositories.House;
using Team_Job.DAL.Repositories.User;
using Team_Job.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDb"));
});

// Add identity

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>

{

    options.User.RequireUniqueEmail = true;

    options.Password.RequiredUniqueChars = 0;

    options.Password.RequireNonAlphanumeric = false;

    options.Password.RequireDigit = false;

    options.Password.RequireLowercase = false;

    options.Password.RequireUppercase = false;

    options.Password.RequiredLength = 6;

})

    .AddDefaultTokenProviders()

    .AddEntityFrameworkStores<AppDbContext>();

// Add automapper
builder.Services.AddAutoMapper(options =>
{
    options.LicenseKey = builder.Configuration["Automapper:LicenseKey"];
}, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IHouseRepository, HouseRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IStorageService, StorageService>();

builder.Services.AddScoped<IHouseService, HouseService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string corsPolicy = "allowall";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.AddStaticFiles(app.Environment);

app.MapControllers();
app.UseCors(corsPolicy);
app.Seed();

app.Run();

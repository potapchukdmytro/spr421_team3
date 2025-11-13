using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Team_Job.BLL.Dtos.Booking;
using Team_Job.DAL.Entities;
using Team_Job.DAL.Repositories.Booking;
using Team_Job.DAL.Repositories.House;
using Team_Job.DAL.Repositories.User;

namespace Team_Job.BLL.Services.Booking
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly IHouseRepository _houseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IMapper mapper, IHouseRepository houseRepository, IUserRepository userRepository,IBookingRepository bookingRepository)
        {
            _houseRepository = houseRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }
        public async Task<ServiceResponse> CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            var user = _userRepository.GetByIdAsync(createBookingDto.UserId);
            if (user == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Юзера з id '{createBookingDto.UserId}' не існує",
                    StatusCode = HttpStatusCode.BadRequest      
                };
            }

            var house = _houseRepository.GetByIdAsync(createBookingDto.HouseId);

            if (house == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Будинку з id '{createBookingDto.HouseId}' не існує",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            var entity = _mapper.Map<BookingEntity>(createBookingDto);


            await _bookingRepository.CreateAsync(entity);

            return new ServiceResponse
            {
                Message = $"Бронювання будинку '{house.Result.Address}' користувачем '{user.Result.Name} {user.Result.Surname}' створено успішно",
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<ServiceResponse> DeleteBookingAsync(string id)
        {
           var book = await _bookingRepository.GetByIdAsync(id);

            if (book == null)
              {
              return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Бронювання з id '{id}' не знайдено",
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            await _bookingRepository.DeleteAsync(book);

            var house = await _houseRepository.GetByIdAsync(book.HouseId);
            if (house != null)
            {
                house.IsAvialable = true;
                await _houseRepository.UpdateAsync(house);
            }

            return new ServiceResponse
            {
                Message = $"Бронювання з id '{id}' успішно видалено, будинок знову доступний.",
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK
            };

            return new ServiceResponse
            {
                Message = $"Бронювання з id '{id}' успішно видалено",
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<ServiceResponse> GetAllAsync()
        {
            var bookings = _bookingRepository.Bookings.ToList();
            var bookingDtos = _mapper.Map<List<BookingDto>>(bookings);
            if (bookingDtos.Count == 0)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Бронювань не знайдено",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            return new ServiceResponse
            {
                Message = "Список всіх бронювань",
                IsSuccess = true,
                Payload = bookingDtos,
                StatusCode = HttpStatusCode.OK
            };

        }

        public async Task<ServiceResponse> GetByIdAsync(string id)
        {
            var bookings = await _bookingRepository.GetByIdAsync(id);
            var bookingDtos = _mapper.Map<BookingDto>(bookings);
            if (bookingDtos == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Бронювань не знайдено",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            return new ServiceResponse
            {
                Message = "Список всіх бронювань",
                IsSuccess = true,
                Payload = bookingDtos,
                StatusCode = HttpStatusCode.OK
            };

        }

      

        public async Task<ServiceResponse> UpdateBookingAsync(UpdateBookingDto updateBookingDto)
        {
            var booking = await _bookingRepository.GetByIdAsync(updateBookingDto.Id);
            if (booking == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Бронювання з id '{updateBookingDto.Id}' не знайдено",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            var house = await _houseRepository.GetByIdAsync(updateBookingDto.HouseId);

            if (house == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Будинку з id '{updateBookingDto.HouseId}' не існує",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            var user = await _userRepository.GetByIdAsync(updateBookingDto.UserId);

            if (user == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Юзера з id '{updateBookingDto.UserId}' не існує",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            _mapper.Map(updateBookingDto, booking);

            await _bookingRepository.UpdateAsync(booking);

            return new ServiceResponse
            {
                Message = $"Бронювання з id '{updateBookingDto.Id}' успішно оновлено",
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK
            };

        }



        public async Task<ServiceResponse> ReserveAsync(CreateBookingDto dto)
        {
            var user = await _userRepository.GetByIdAsync(dto.UserId);
            if (user == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Користувача з id '{dto.UserId}' не існує",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            var house = await _houseRepository.GetByIdAsync(dto.HouseId);
            if (house == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Будинку з id '{dto.HouseId}' не існує",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            if (!house.IsAvialable)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Будинок '{house.Address}' уже заброньований",
                    StatusCode = HttpStatusCode.Conflict
                };
            }

            var days = (dto.EndDate - DateTime.UtcNow).Days;
            if (days <= 0)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Дата завершення має бути пізнішою за поточну",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            var totalPrice = days * house.PricePerNight;

            var booking = new BookingEntity
            {
                Id = Guid.NewGuid().ToString(),
                HouseId = dto.HouseId,
                UserId = dto.UserId,
                CreatedDate = DateTime.UtcNow,
                EndDate = dto.EndDate,
                TotalPrice = totalPrice,
                House = house,
                User = user
            };

            await _bookingRepository.CreateAsync(booking);

            house.IsAvialable = false;
            await _houseRepository.UpdateAsync(house);

            return new ServiceResponse
            {
                Message = $"Будинок '{house.Address}' заброньовано користувачем '{user.Name} {user.Surname}' до {dto.EndDate:d}.",
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Payload = new
                {
                    booking.Id,
                    booking.TotalPrice,
                    booking.EndDate
                }
            };
        }


        public async Task<ServiceResponse> FilterBookingsAsync(string? userId = null, string? houseId = null, DateTime? from = null, DateTime? to = null)
        {
            var bookings = _bookingRepository.Bookings.AsQueryable();

            if (!string.IsNullOrEmpty(userId))
                bookings = bookings.Where(b => b.UserId == userId);

            if (!string.IsNullOrEmpty(houseId))
                bookings = bookings.Where(b => b.HouseId == houseId);

            if (from.HasValue)
                bookings = bookings.Where(b => b.CreatedDate >= from.Value);

            if (to.HasValue)
                bookings = bookings.Where(b => b.CreatedDate <= to.Value);

            var bookingDtos = _mapper.Map<List<BookingDto>>(bookings.ToList());

            return new ServiceResponse
            {
                IsSuccess = true,
                Message = bookingDtos.Any() ? "Фільтровані бронювання" : "Бронювань не знайдено",
                Payload = bookingDtos,
                StatusCode = HttpStatusCode.OK
            };
        }


    }
}

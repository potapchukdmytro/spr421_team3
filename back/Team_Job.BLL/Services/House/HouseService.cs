using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Team_Job.BLL.Dtos.House;
using Team_Job.DAL.Entities;
using Team_Job.DAL.Repositories.House;
using Team_Job.DAL.Repositories.User;

namespace Team_Job.BLL.Services.House
{
    public class HouseService : IHouseService
    {
        private readonly IMapper _mapper;
        private readonly IHouseRepository _houseRepository;
        private readonly IUserRepository _userRepository;

        public HouseService(IMapper mapper, IHouseRepository houseRepository, IUserRepository userRepository)
        {
            _houseRepository = houseRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse> CreateAsync(CreateHouseDto houseDto)
        {
            var entity = _mapper.Map<HouseEntity>(houseDto);

            var user = await _userRepository.GetByIdAsync(houseDto.OwnerId);

            if (user == null) {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"Власник з id '{houseDto.OwnerId}' не знайдено"
                };
            }

            entity.Owner = user;

            await _houseRepository.CreateAsync(entity);

            return new ServiceResponse
            {
                Message = $"Будинок '{entity.Address}' додано"
            };
        }

        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var entity = await _houseRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"Будинок з id '{id}' не знайдено"
                };
            }

            await _houseRepository.DeleteAsync(entity);

            return new ServiceResponse
            {
                Message = $"Будинок '{id}' видалено"
            };
        }

        public async Task<ServiceResponse> GetAllAsync()
        {
            var entities = await _houseRepository.Houses
                .Include(h => h.Owner)
                .ToListAsync();

            var dtos = _mapper.Map<List<HouseDto>>(entities);

            return new ServiceResponse
            {
                Message = "Houses",
                Payload = dtos
            };
        }

        public async Task<ServiceResponse> GetByIdAsync(string id)
        {
           var house = await _houseRepository.GetByIdAsync(id);

              if (house == null)
              {
                return new ServiceResponse
                {
                     IsSuccess = false,
                     StatusCode = HttpStatusCode.NotFound,
                     Message = $"Будинок з id '{id}' не знайдено"
                };
            }

              var houseDto = _mapper.Map<HouseDto>(house);
                return new ServiceResponse
                {
                    Message = $"Будинок з id '{id}'",
                    Payload = houseDto
                };
        }

        public async Task<ServiceResponse> GetByNameAsync(string name)
        {
            var houses =   _houseRepository.GetByAddress(name);

            if (houses == null || !houses.Any())
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"Будинки з адресою, що містить '{name}', не знайдено"
                };
            }

            var houseDtos = _mapper.Map<List<HouseDto>>(houses);

            return new ServiceResponse
            {
                Message = $"Будинки з адресою, що містить '{name}'",
                Payload = houseDtos
            };

        }

        public async Task<ServiceResponse> UpdateAsync(UpdateHouseDto houseDto)
        {
            var entity = await _houseRepository.GetByIdAsync(houseDto.Id);

            if (entity == null)
            {
               return  new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"Будинок з id '{houseDto.Id}' не знайдено"
                };
            }

            var dto = _mapper.Map<UpdateHouseDto>(entity);

            return new ServiceResponse
            {
                Message = $"Будинок по адресі'{houseDto.Address}' оновлено"
            };
        }
    }
}

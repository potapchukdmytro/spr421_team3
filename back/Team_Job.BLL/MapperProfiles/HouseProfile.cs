using AutoMapper;
using Team_Job.BLL.Dtos.House;
using Team_Job.DAL.Entities;

namespace Team_Job.BLL.MapperProfiles
{
    public class HouseProfile : Profile
    {
        public HouseProfile() 
        {
            CreateMap<CreateHouseDto, HouseEntity>();
            CreateMap<HouseEntity, HouseDto>();
        }
    }
}

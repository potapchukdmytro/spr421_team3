using Team_Job.BLL.Dtos.House;

namespace Team_Job.BLL.Services.House
{
    public interface IHouseService
    {
        Task<ServiceResponse> CreateAsync(CreateHouseDto houseDto);
        Task<ServiceResponse> DeleteAsync(string id);
        Task<ServiceResponse> GetAllAsync();
    }
}

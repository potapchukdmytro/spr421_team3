using Team_Job.BLL.Dtos.House;

namespace Team_Job.BLL.Services.House
{
    public interface IHouseService
    {
        Task<ServiceResponse> CreateAsync(CreateHouseDto houseDto);
        Task<ServiceResponse> DeleteAsync(string id);
        Task<ServiceResponse> GetAllAsync();

        Task<ServiceResponse> GetByIdAsync(string id);

        Task<ServiceResponse> GetByNameAsync(string name);

        Task<ServiceResponse> UpdateAsync(UpdateHouseDto houseDto);
    }
}

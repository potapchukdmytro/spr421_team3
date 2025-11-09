using Microsoft.AspNetCore.Http;

namespace Team_Job.BLL.Services.Storage
{
    public interface IStorageService
    {

        Task<string?> SaveImageFileAsync(IFormFile imageFile, string folderPath);
    }
}

using Microsoft.AspNetCore.Http;

namespace Web
{
    public interface IFileService
    {
        Task<string> AddFileAsync(string folderName, IFormFile file);

        Task<bool> DeleteFileAsync(string folderName,string fileName);
    }
}


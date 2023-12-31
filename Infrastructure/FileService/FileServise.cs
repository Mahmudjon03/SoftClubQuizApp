using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Web
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;


        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment; 
        }

        public async Task<string> AddFileAsync(string folderName, IFormFile file)
        {
            try
            {
                string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, folderName);
                if (Directory.Exists(folderPath) == false) Directory.CreateDirectory(folderPath);
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                folderPath = Path.Combine(folderPath, fileName);
                using var stream = new FileStream(folderPath, FileMode.OpenOrCreate);
                await file.CopyToAsync(stream);
                return fileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<bool> DeleteFileAsync(string folderName, string fileName)
        {
            return await Task.Run(() =>
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", folderName, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
                return false;
            });
        }
    }
 }

       
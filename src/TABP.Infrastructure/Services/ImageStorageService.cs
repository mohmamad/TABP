using Microsoft.AspNetCore.Http;
using TABP.Domain.Interfaces;

namespace TABP.Infrastructure.Services
{
    public class ImageStorageService : IImageStorageService
    {
        private readonly string _basePath;
        public ImageStorageService(string basePath) 
        {
            _basePath = basePath;
        }
        public async  Task<string> StoreImage(IFormFile image, string fileName)
        {
            var filePath = Path.Combine(_basePath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return filePath;
        }
    }
}

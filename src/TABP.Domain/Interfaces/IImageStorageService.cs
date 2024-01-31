using Microsoft.AspNetCore.Http;

namespace TABP.Domain.Interfaces
{
    public interface IImageStorageService
    {
        public Task<string> StoreImage(IFormFile image, string fileName);
    }
}

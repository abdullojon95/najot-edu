using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NajotEdu.Application.Abstractions;

namespace NajotEdu.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> Upload(IFormFile formFile)
        {
            var fileNameItems = formFile.FileName.Split(".");
            var extension = fileNameItems[fileNameItems.Length - 1];
            var fileName = formFile.FileName.Remove(formFile.FileName.IndexOf(extension, StringComparison.InvariantCultureIgnoreCase)-1);

            var path = $"/Files/{fileName}-{Guid.NewGuid()}.{extension}";

            var fullPath = _webHostEnvironment.WebRootPath + path;

            using (var fileStream = new FileStream(fullPath, FileMode.CreateNew))
            {
                await formFile.CopyToAsync(fileStream);
            }

            return path;
        }
    }
}

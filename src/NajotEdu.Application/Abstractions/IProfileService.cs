using Microsoft.AspNetCore.Http;
using NajotEdu.Application.Models;

namespace NajotEdu.Application.Abstractions
{
    public interface IProfileService
    {
        Task SetPhoto(IFormFile formFile);
        Task<ProfileViewModel> GetProfile();
    }
}

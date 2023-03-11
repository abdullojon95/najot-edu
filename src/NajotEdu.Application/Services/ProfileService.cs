using Microsoft.EntityFrameworkCore;
using NajotEdu.Application.Abstractions;
using NajotEdu.Application.Models;

namespace NajotEdu.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IFileService _fileService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IApplicationDbContext _context;

        public ProfileService(IFileService fileService, ICurrentUserService currentUserService, IApplicationDbContext context)
        {
            _fileService = fileService;
            _currentUserService = currentUserService;
            _context = context;
        }

        public async Task<ProfileViewModel> GetProfile()
        {
            var userId = _currentUserService.UserId;
            var user = await _context.Users.Include(x => x.Groups).FirstOrDefaultAsync(x => x.Id == userId);

            return new ProfileViewModel()
            {
                UserName = user.UserName,
                FullName = user.FullName,
                PhotoPath = user.PhotoPath,
                Groups = new List<GroupViewModel>(user.Groups.Select(x => new GroupViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    TeacherId = x.TeacherId,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                }))
            };
        }

        public async Task SetPhoto(IFormFile formFile)
        {
            var userId = _currentUserService.UserId;
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var path = await _fileService.Upload(formFile);

            user.PhotoPath = path;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}

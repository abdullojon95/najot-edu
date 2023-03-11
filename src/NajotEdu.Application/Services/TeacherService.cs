using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NajotEdu.Application.Abstractions;
using NajotEdu.Application.Models;
using NajotEdu.Domain.Entities;
using NajotEdu.Domain.Enums;

namespace NajotEdu.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IApplicationDbContext _context;
        private readonly IHashProvider _hashProvider;
        private readonly IMapper _mapper;
        public TeacherService(IApplicationDbContext context, IHashProvider hashProvider,IMapper mapper)
        {
            _context = context;
            _hashProvider = hashProvider;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateTeacherModel model)
        {
            var entity = _mapper.Map<User>(model);
            /*var user = new User()
            {
                UserName = model.UserName,
                PasswordHash = _hashProvider.GetHash(model.Password),
                FullName = model.FullName,
                Role = UserRole.Teacher
            };*/

            entity.PasswordHash = _hashProvider.GetHash(model.Password);
            entity.Role = UserRole.Teacher;

            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.Role == UserRole.Teacher);
            if (entity == null)
            {
                throw new Exception("Not found");
            }

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TeacherViewModel>> GetAllAsync()
        {
            var list = await _context.Users
                 .Where(x => x.Role == UserRole.Teacher)
                 .ToListAsync();

            return _mapper.Map<List<TeacherViewModel>>(list);
        }

        public async Task<TeacherViewModel> GetByIdAsync(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.Role == UserRole.Teacher);

            return _mapper.Map<TeacherViewModel>(entity);
        }

        public async Task UpdateAsync(UpdateTeacherModel model)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.Id && x.Role == UserRole.Teacher);
            if (entity == null)
            {
                throw new Exception("Not found");
            }

            entity.UserName = model.UserName ?? entity.UserName;
            entity.FullName = model.FullName ?? entity.FullName;
            entity.PasswordHash = model.Password == null ? entity.PasswordHash : _hashProvider.GetHash(model.Password);

            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}

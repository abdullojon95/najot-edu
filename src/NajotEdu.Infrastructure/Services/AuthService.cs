using Microsoft.EntityFrameworkCore;
using NajotEdu.Infrastructure.Abstractions;
using NajotEdu.Infrastructure.Persistence;
using NajotEdu.Infrastructure.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajotEdu.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        public readonly ApplicationDbContext _dbContext;
        public readonly ITokenService _tokenService;
        public AuthService(ApplicationDbContext dbContext,ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }
        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.PasswordHash != HashGenerator.Generate(password))
            {
                throw new Exception("Password is wrong");
            }

            return _tokenService.GenerateAccessToken(user);
        }
    }
}

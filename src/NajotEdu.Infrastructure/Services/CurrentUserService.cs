using Microsoft.AspNetCore.Http;
using NajotEdu.Application.Abstractions;
using System.Security.Claims;

namespace NajotEdu.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int UserId { get; set; } = 3;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            var userClaims = contextAccessor.HttpContext!.User.Claims;

            var idClaim = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name);

            if (idClaim != null && int.TryParse(idClaim.Value, out int value))
            {
                UserId = value;
            }
        }
    }
}

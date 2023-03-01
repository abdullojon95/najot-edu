using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Najot_edu.Api.Models;
using NajotEdu.Application.Abstractions;
using NajotEdu.Infrastructure.Abstractions;
using System.Collections;

namespace Najot_edu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHashProvider _hashProvider;
        public AuthController(IAuthService authService,IHashProvider hashProvider)
        {
            _authService = authService;
            _hashProvider = hashProvider;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var token = await _authService.LoginAsync(request.UserName,request.Password);

            return Ok(token);
        }
    }
}

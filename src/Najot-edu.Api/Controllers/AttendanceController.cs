using Microsoft.AspNetCore.Mvc;

namespace Najot_edu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost("check")]

        public async Task<IActionResult> AttendanceCheck(DoAttendanceCheckModel model)
        {
            await _attendanceService.CheckAsync(model);

            return Ok();
        }
    }
}

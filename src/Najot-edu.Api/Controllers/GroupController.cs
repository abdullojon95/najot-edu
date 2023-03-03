using Microsoft.AspNetCore.Mvc;
using NajotEdu.Application.Abstractions;
using NajotEdu.Application.Models;

namespace Najot_edu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGroupModel model)
        {
            await _groupService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var group = await _groupService.GetByIdAsync(id);
            return Ok(group);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var groups = await _groupService.GetAllAsync();
            return Ok(groups);
        }

        [HttpPut]
        public async Task<IActionResult> Create(UpdateGroupModel model)
        {
            await _groupService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupService.DeleteAsync(id);

            return Ok();
        }

        [HttpPost("{groupId}/student")]
        public async Task<IActionResult> AddStudent([FromRoute] int groupId, AddStudentGroupModel model)
        {
            await _groupService.AddStudentAsync(model, groupId);
            return Ok();
        }

        [HttpDelete("{groupId}/student")]
        public async Task<IActionResult> RemoveStudent([FromRoute] int groupId, [FromBody] int studentId)
        {
            await _groupService.RemoveStudentAsync(studentId, groupId);
            return Ok();
        }
    }
}

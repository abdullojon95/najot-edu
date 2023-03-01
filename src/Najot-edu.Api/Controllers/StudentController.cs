using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NajotEdu.Application.Abstractions;
using NajotEdu.Application.Models;
using NajotEdu.Application.Services;

namespace Najot_edu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy ="AdminActions")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentModel model)
        {
            await _studentService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpPut]
        public async Task<IActionResult> Create(UpdateStudentModel model)
        {
            await _studentService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteAsync(id);

            return Ok();
        }
    }
}

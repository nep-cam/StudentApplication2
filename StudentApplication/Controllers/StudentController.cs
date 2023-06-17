using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.Dto.Student;
using StudentApplication.Service.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StudentApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
         
        [HttpPost("create")]
        public IActionResult CreateStudent(CreateStudentDto input)
        {
            try
            {

                _studentService.Create(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });

                
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateStudent( UpdateStudentDto input)
        {
            try
            {
                _studentService.Update(input);

                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
            
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById([Range(1, int.MaxValue, ErrorMessage = "Id phải lớn hơn 0")] int id)
        {
                _studentService.getById(id);

            return Ok();
        }

     
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([Range(1, int.MaxValue, ErrorMessage = "Id phải lớn hơn 0")] int id)
        {
            try
            {
                _studentService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}

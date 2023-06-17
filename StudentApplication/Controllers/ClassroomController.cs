using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.Dto.ClassroomDto;
using StudentApplication.Service.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StudentApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomService _classroomService;

        public ClassroomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        [HttpPost("create")]
        public IActionResult Create(CreateClassroomDto input)
        {
            try
            {
                _classroomService.Create(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });


            }
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateClassroomDto input)
        {
            try
            {
                _classroomService.Update(input);

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
            _classroomService.GetById(id);

            return Ok();
        }


        [HttpGet("get-all-student")]
        public IActionResult GetAll([Range(1, int.MaxValue, ErrorMessage = "Id phải lớn hơn 0")] int id)
        {
            return Ok(_classroomService.GetAllStudent(id));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteClassroom([Range(1, int.MaxValue, ErrorMessage = "Id phải lớn hơn 0")] int id)
        {
            try
            {
                _classroomService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}

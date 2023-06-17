using System.ComponentModel.DataAnnotations;

namespace StudentApplication.Dto.Student
{
    public class CreateStudentDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên không được bỏ trống")]
        [StringLength(50, ErrorMessage ="Tối đa 50 ký tự")]
        public string Name { set; get; }
        public string StudentCode { set; get; }
        public DateOnly DateOfBirth { set; get; }
    }
}

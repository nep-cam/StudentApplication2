using System.ComponentModel.DataAnnotations;

namespace StudentApplication.Dto.ClassroomDto
{
    public class CreateClassroomDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên không được bỏ trống")]
        [MaxLength(50, ErrorMessage = "Tối đa 50 ký tự")]
        public string ClassName { get; set; }

        [MinLength(5, ErrorMessage ="tối thiểu 5 ký tự")]
        public string ClassCode { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Nhập số phải lớn hơn 0")]
        public int MaxNumber { get; set; }
    }
}

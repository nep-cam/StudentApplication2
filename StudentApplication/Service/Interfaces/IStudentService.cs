using StudentApplication.Dto.Student;

namespace StudentApplication.Service.Interfaces
{
    public interface IStudentService
    {
        void Create(CreateStudentDto input);
        List<StudentDto> GetAll();
        void Update(UpdateStudentDto input);
        void Delete(int id);
        StudentDto getById(int id);


    }
}

using StudentApplication.Dto.ClassroomDto;
using StudentApplication.Dto.Student;

namespace StudentApplication.Service.Interfaces
{
    public interface IClassroomService
    {
        void Create(CreateClassroomDto input);
        void Update(UpdateClassroomDto input);
        ClassroomDto GetById(int id);
        List<StudentDto> GetAllStudent(int classroomId);
        void Delete(int id);
    }
}

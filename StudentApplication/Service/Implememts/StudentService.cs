using StudentApplication.DbContexts;
using StudentApplication.Dto.Student;
using StudentApplication.Entity;
using StudentApplication.Exceptions;
using StudentApplication.Service.Interfaces;
using System.Security.Cryptography;

namespace StudentApplication.Service.Implememts
{
    public class StudentService :IStudentService
    {
        private readonly ApplicationDbContext _context;
        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public void Create(CreateStudentDto input)
        {
            _context.Students.Add(new Student
            {
                Id = ++_context.StudentID,
                Name = input.Name,
                StudentCode = input.StudentCode,
                DateOfBirth = input.DateOfBirth
            });
        }
        public List<StudentDto> GetAll()
        {
            var results = new List<StudentDto>();
            foreach (var student in _context.Students)
            {
                results.Add(new StudentDto
                {
                    Name = student.Name,
                    StudentCode = student.StudentCode,
                    DateOfBirth = student.DateOfBirth
                    
                });
            }
            return results;
        }
        public void Update( UpdateStudentDto input)
        {
             var studentFind = _context.Students.FirstOrDefault(s => s.Id == input.Id);
             if (studentFind == null)
             {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id = {input.Id}");
             }
             studentFind.Name = input.Name;
             studentFind.StudentCode = input.StudentCode;
             studentFind.DateOfBirth = input.DateOfBirth;

        }
        public void Delete(int id)
        {
            var studentFind = _context.Students.FirstOrDefault(s => s.Id == id);
            if (studentFind == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id = {id}");
            }
            var studentClassroomFinf = _context.StudentClasses.FirstOrDefault(s => s.StudentId == id);
            if (studentClassroomFinf != null)
            {
                _context.StudentClasses.Remove(studentClassroomFinf);
            }
            _context.Students.Remove(studentFind);
        }
        public StudentDto getById(int id)
        {
            var studentFind = _context.Students.FirstOrDefault(s => s.Id == id);
            if (studentFind == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id = {id}");
            }
            return new StudentDto{
                Name = studentFind.Name,
                StudentCode = studentFind.StudentCode,
                DateOfBirth = studentFind.DateOfBirth
            };
        }
    }
}

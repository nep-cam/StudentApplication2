using StudentApplication.DbContexts;
using StudentApplication.Dto.ClassroomDto;
using StudentApplication.Dto.Student;
using StudentApplication.Entity;
using StudentApplication.Exceptions;
using StudentApplication.Service.Interfaces;

namespace StudentApplication.Service.Implememts
{
    public class ClassroomService : IClassroomService
    {
        private readonly ApplicationDbContext _context;

        public ClassroomService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public void Create(CreateClassroomDto input) {
            _context.Classrooms.Add(new Classroom
            {
                Id = ++_context.ClassroomID,
                ClassName = input.ClassName,
                ClassCode = input.ClassCode,
                MaxNumber = input.MaxNumber

            }) ;
           
        }
        public void Update(UpdateClassroomDto input) {
            var classroomFind = _context.Classrooms.FirstOrDefault(c => c.Id == input.Id);
            if (classroomFind == null)
            {
                throw new UserFriendlyException($"Không tìm thấy lớp học có id = {input.Id}");
            }
            classroomFind.ClassName = input.ClassName;
            classroomFind.ClassCode = input.ClassCode;
            classroomFind.MaxNumber = input.MaxNumber;

        }
        public ClassroomDto GetById(int id) {
            var classroomFind = _context.Classrooms.FirstOrDefault(c => c.Id == id);
            if (classroomFind == null)
            {
                throw new UserFriendlyException($"Không tìm thấy lớp học có id = {id}");
            }
            return new ClassroomDto
            {
                ClassName = classroomFind.ClassName,
                ClassCode  = classroomFind.ClassCode,
                MaxNumber = classroomFind.MaxNumber,
            };
        }
        public List<StudentDto> GetAllStudent(int classroomId)
        {
            var query = from studentClassroom in _context.StudentClasses
                        join student in _context.Students on studentClassroom.Id equals student.Id
                        where studentClassroom.Id == classroomId
                        select new StudentDto
                        {
                            Name = student.Name,
                            StudentCode = student.StudentCode,
                            DateOfBirth = student.DateOfBirth
                        };
            return query.ToList();
        }
        public void Delete(int id)
        {
            var classroomFind = _context.Classrooms.FirstOrDefault(c => c.Id == id);
            if (classroomFind == null)
            {
                throw new UserFriendlyException($"Không tìm thấy lớp học có id = {id}");
            }
            var studentClassroomFind = _context.StudentClasses.FirstOrDefault(s => s.ClassroomId == id);
            if (studentClassroomFind != null)
            {
                _context.StudentClasses.Remove(studentClassroomFind);
            }
            var query = from studentClassroom in _context.StudentClasses
                        join student in _context.Students on studentClassroom.Id equals student.Id
                        where studentClassroom.Id == id
                        select student;
            List<Student> studenDelete = query.ToList();
            foreach (Student student in studenDelete)
            {
                _context.Students.Remove(student);
            }
            _context.Classrooms.Remove(classroomFind);
        }
    }

}

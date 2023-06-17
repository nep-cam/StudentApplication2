using StudentApplication.Entity;

namespace StudentApplication.DbContexts
{
    public class ApplicationDbContext
    {
        public List<Student> Students = new();
        public int StudentID = 0;
        public List<Classroom> Classrooms = new();
        public int ClassroomID = 0;
        public List<StudentClassroom> StudentClasses = new();
        public int StudentClassroomId = 0;
    }
}

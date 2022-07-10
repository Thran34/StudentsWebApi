using StudentsWebApi.Domain.ValueObjects;

namespace StudentsWebApi.Domain.Model
{
    public class Teacher
    {
        public int Id { get; set; }

        public PersonName? TeacherFullName { get; set; }
    }
}

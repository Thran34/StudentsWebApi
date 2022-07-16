using StudentsWebApi.Domain.ValueObjects;

namespace StudentsWebApi.Domain.Model
{
    public class Student
    {
        public int Id { get; set; }
        public PersonName? StudentFullName { get; set; }
        public int Age { get; set; }
        public PersonName? ParentFullName { get; set; }
        public Email? Email { get; set; }
        public string PhoneNumber { get; set; }
        public Lesson? Lesson { get; set; }
        public Teacher? Teacher { get; set; }
    }
}

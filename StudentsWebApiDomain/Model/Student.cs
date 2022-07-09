using StudentsWebApi.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsWebApi.Domain.Model
{
    public class Student
    {
        public int Id { get; set; }
        [NotMapped]
        public PersonName? StudentFullName { get; set; }
        public int Age { get; set; }
        [NotMapped]
        public PersonName? ParentFullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Lesson? Lesson { get; set; }
        public Teacher? Teacher { get; set; }
    }
}

using StudentsWebApi.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsWebApi.Domain.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        [NotMapped]
        public PersonName? TeacherFullName { get; set; }
    }
}

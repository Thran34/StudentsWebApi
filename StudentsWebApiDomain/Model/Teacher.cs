using StudentsWebApi.Domain.Common;
using StudentsWebApi.Domain.ValueObjects;

namespace StudentsWebApi.Domain.Model
{
    public class Teacher : AuditableEntity
    {
        public PersonName? TeacherFullName { get; set; }
    }
}

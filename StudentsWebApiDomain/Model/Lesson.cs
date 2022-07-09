namespace StudentsWebApi.Domain.Model
{
    public class Lesson
    {
        public int Id { get; set; }
        public string LessonSubject { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}

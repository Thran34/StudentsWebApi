namespace StudentsWebApi.Model
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string LessonSubject { get; set; }
        public ICollection<Student> Students { get; set; }
        public Teacher Teacher { get; set; }

    }
}

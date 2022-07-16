using System.Text.Json.Serialization;

namespace StudentsWebApi.Domain.Model
{
    public class Lesson
    {
        public int Id { get; set; }
        public string LessonSubject { get; set; }
        [JsonIgnore]
        public IEnumerable<Student>? Students { get; set; }
        public string Test { get; set; }
        public string Develop { get; set; }

    }
}

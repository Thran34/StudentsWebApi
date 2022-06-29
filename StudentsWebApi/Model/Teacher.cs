namespace StudentsWebApi.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Lesson> Lessons { get; set; }

    }
}

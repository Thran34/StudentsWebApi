﻿namespace StudentsWebApi.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<string> Subjects { get; set; }
    }
}

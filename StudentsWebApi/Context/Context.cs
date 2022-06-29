using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsWebApi.Model;

namespace StudentsWebApi.Context
{
    public class Context : IdentityDbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}

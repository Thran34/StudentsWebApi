using Microsoft.EntityFrameworkCore;
using StudentsWebApi.Model;

namespace StudentsWebApi.Context
{
    public class DBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }
    }
}

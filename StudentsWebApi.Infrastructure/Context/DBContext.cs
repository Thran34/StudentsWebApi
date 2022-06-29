using Microsoft.EntityFrameworkCore;
using StudentsWebApi.Domain.Model;

namespace StudentsWebApi.Infrastructure.Context
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
            modelBuilder.Entity<Student>().HasOne(k => k.Teacher);



            base.OnModelCreating(modelBuilder);
        }
    }
}

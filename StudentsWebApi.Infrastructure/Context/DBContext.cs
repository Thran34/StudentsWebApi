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
            modelBuilder.Entity<Student>().HasOne(s => s.Teacher);
            modelBuilder.Entity<Lesson>().HasMany(l => l.Students)
                .WithOne(s => s.Lesson)
                .IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}

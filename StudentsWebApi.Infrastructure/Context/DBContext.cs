using Microsoft.EntityFrameworkCore;
using StudentsWebApi.Domain.Common;
using StudentsWebApi.Domain.Model;
using StudentsWebApi.Domain.ValueObjects;

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
            modelBuilder.Entity<Lesson>().HasMany(l => l.Students)
                    .WithOne(s => s.Lesson)
                    .IsRequired();
            modelBuilder.Entity<Student>().OwnsOne(typeof(PersonName), "StudentFullName");
            modelBuilder.Entity<Student>().OwnsOne(typeof(PersonName), "ParentFullName");
            modelBuilder.Entity<Teacher>().OwnsOne(typeof(PersonName), "TeacherFullName");


            modelBuilder.Entity<Student>().OwnsOne(typeof(Email), "Email");


            base.OnModelCreating(modelBuilder);


        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = string.Empty;
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = DateTime.Now;
                        entry.Entity.Inactivated = DateTime.Now;
                        entry.Entity.InactivatedBy = string.Empty;
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

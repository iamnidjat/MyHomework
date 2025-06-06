using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace backend.Services
{
    public class MyHomeworkDbContext : DbContext
    {
        public MyHomeworkDbContext(DbContextOptions<MyHomeworkDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TeacherProfile> TeacherProfiles { get; set; }

        public DbSet<StudentProfile> StudentProfiles { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Group> Groups { get; set; }
    }
}

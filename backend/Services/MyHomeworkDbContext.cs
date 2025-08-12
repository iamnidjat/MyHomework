using backend.Models;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Dislike> Dislikes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<TeacherProfileClosingRequest> TeacherProfileClosingRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnitTeacher>()
                .HasKey(sc => new { sc.UnitId, sc.TeacherProfileId });

            modelBuilder.Entity<UnitTeacher>()
                .HasOne(sc => sc.Unit)
                .WithMany(s => s.UnitTeachers)
                .HasForeignKey(sc => sc.UnitId);

            modelBuilder.Entity<UnitTeacher>()
                .HasOne(sc => sc.TeacherProfile)
                .WithMany(s => s.UnitTeachers)
                .HasForeignKey(sc => sc.TeacherProfileId);


            modelBuilder.Entity<GroupHomework>()
                .HasKey(sc => new { sc.GroupId, sc.HomeworkId });

            modelBuilder.Entity<GroupHomework>()
                .HasOne(sc => sc.Group)
                .WithMany(s => s.GroupHomeworks)
                .HasForeignKey(sc => sc.GroupId);

            modelBuilder.Entity<GroupHomework>()
                .HasOne(sc => sc.Homework)
                .WithMany(s => s.GroupHomeworks)
                .HasForeignKey(sc => sc.HomeworkId);
        }
    }
}

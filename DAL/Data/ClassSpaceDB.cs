using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ClassSpaceDB : DbContext
    {
        public ClassSpaceDB(DbContextOptions options) : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Student)
                .WithMany()
                .HasForeignKey(q => q.StudentID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Teacher)
                .WithMany()
                .HasForeignKey(q => q.TeacherID)
                .OnDelete(DeleteBehavior.NoAction);

            // מפתח כפול: אותה תלמידה לא יכולה לסמן "גם אני" פעמיים על אותה שאלה
            modelBuilder.Entity<Vote>()
                .HasKey(v => new { v.QuestionID, v.StudentID });

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Question)
                .WithMany()
                .HasForeignKey(v => v.QuestionID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Student)
                .WithMany()
                .HasForeignKey(v => v.StudentID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

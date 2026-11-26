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
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<StudyUnit> StudyUnits { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentUnit> AssignmentUnits { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Material> Materials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClassSpaceDB;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudyUnit>().HasKey(u => u.UnitId);
            modelBuilder.Entity<AssignmentUnit>().HasKey(au => new { au.AssignmentID, au.UnitID });
            modelBuilder.Entity<Vote>().HasKey(v => new { v.QuestionID, v.StudentID });

            modelBuilder.Entity<AssignmentUnit>()
                .HasOne(au => au.Unit)
                .WithMany()
                .HasForeignKey(au => au.UnitID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Student)
                .WithMany()
                .HasForeignKey(q => q.StudentID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.TeacherSubject)
                .WithMany()
                .HasForeignKey(q => q.TeacherSubjectID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Unit)
                .WithMany()
                .HasForeignKey(q => q.UnitID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Student)
                .WithMany()
                .HasForeignKey(v => v.StudentID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Material>()
                .HasOne(m => m.UploadedBy)
                .WithMany()
                .HasForeignKey(m => m.UploadedByID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Material>()
                .HasOne(m => m.Unit)
                .WithMany()
                .HasForeignKey(m => m.UnitID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

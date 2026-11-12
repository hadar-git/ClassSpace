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


    }
}

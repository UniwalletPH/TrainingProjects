using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using StudentEnrollmentSystem.Application.Interfaces;
using StudentEnrollmentSystem.Domain.Entities;
using StudentEnrollmentSystem.Domain.Entities.Base;

namespace StudentEnrollmentSystem.Infrastructure.Persistence
{
    public class StudentEnrollmentSystemDbContext : DbContext, IStudentEnrollmentSystemDbContext
    {

        public DbSet<StudentBasicInfo> StudentBasicInfos { get; set; }

        public DbSet<StudentSubjects> StudentSubjects { get; set; }

        public DbSet<EnrollmentDetails> EnrollmentDetails { get; set; }

        public DbSet<StudentSubjectList> StudentSubjectLists { get; set; }

        public DbSet<StudentProfessor> StudentProfessors { get; set; }

        public DbSet<StudentDTR> StudentDTRs { get; set; }

        public DbSet<StudentTimeIn> StudentsTimeIn { get; set; }

        public DbSet<StudentTimeOut> StudentsTimeOut { get; set; }

        public DbSet<StudentDailyTimeRecord> StudentDailyTimeRecords { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StudentEnrollmentSystemDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentEnrollmentSystemDbContext).Assembly);
        }
    }
}


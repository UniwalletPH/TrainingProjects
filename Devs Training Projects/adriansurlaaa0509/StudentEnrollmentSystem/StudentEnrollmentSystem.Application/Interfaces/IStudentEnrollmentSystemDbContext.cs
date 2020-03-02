using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StudentEnrollmentSystem.Domain.Entities;
using StudentEnrollmentSystem.Domain.Entities.Base;

namespace StudentEnrollmentSystem.Application.Interfaces
{
    public interface IStudentEnrollmentSystemDbContext
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

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

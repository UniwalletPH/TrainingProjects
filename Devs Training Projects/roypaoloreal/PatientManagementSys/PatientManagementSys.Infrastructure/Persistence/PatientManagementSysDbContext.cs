using Microsoft.EntityFrameworkCore;
using PatientManagementSys.Application.Interfaces;
using PatientManagementSys.Domain.Entities;


namespace PatientManagementSys.Infrastructure.Persistence
{
    public class PatientManagementSysDbContext : DbContext, IPatientManagementSysDbContext
    {
        public DbSet<PatientRecords> PatientRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PatientManagementSysDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatientManagementSysDbContext).Assembly);
        }
    }
}

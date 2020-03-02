using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientManagementSys.Domain.Entities;
using System;

//PERSISTENCE HERE
namespace PatientManagementSys.Infrastructure.Persistence.Configurations
{
    public class AddPatientRecordConfiguration : IEntityTypeConfiguration<PatientRecords>
    {
        public void Configure(EntityTypeBuilder<PatientRecords> builder)
        {
            
        }
    }
}

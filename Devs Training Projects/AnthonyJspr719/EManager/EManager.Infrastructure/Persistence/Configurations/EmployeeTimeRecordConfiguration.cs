using EManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EManager.Infrastructure.Persistence.Configurations
{
    public class EmployeeTimeRecordConfiguration : IEntityTypeConfiguration<EmployeeTimeRecords>
    {
        public void Configure(EntityTypeBuilder<EmployeeTimeRecords> builder)
        {
            builder.HasOne(a => a.EmployeeInformation).WithMany(b => b.EmployeeTimeRecords).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

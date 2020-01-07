using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PatientManagementSys.Domain.Entities;

namespace PatientManagementSys.Application.Interfaces
{
    public interface IPatientManagementSysDbContext
    {
        public DbSet<PatientRecords> PatientRecords { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}

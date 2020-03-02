using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EManager.Application.Interfaces
{
    public interface IEManagerDbContext
    {

        public DbSet<EmployeeInformation> EmployeeInformation { get; set; }

        public DbSet<EmployeeTimeRecords> EmployeeTimeRecords { get; set; }
        

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

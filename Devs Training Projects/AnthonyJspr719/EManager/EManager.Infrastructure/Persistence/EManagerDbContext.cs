using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EManager.Application.Interfaces;
using EManager.Domain.Entities;
using System.Configuration;

namespace EManager.Infrastructure.Persistence
{
    public class EManagerDbContext : DbContext, IEManagerDbContext
    {

        public DbSet<EmployeeInformation> EmployeeInformation { get; set; }
        public DbSet<EmployeeTimeRecords> EmployeeTimeRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EManagerDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EManagerDbContext).Assembly);
        }

    }
}


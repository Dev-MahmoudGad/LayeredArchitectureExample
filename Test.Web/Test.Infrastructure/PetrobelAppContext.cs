using Microsoft.EntityFrameworkCore;
using Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Test.Infrastructure
{
    public class PetrobelAppContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=PetrobelDemoDb;Integrated security=true; TrustServerCertificate=True");
        }

    }
}

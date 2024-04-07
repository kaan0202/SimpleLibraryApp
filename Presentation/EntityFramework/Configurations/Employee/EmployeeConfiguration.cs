using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Configurations.Employee
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Domain.Entities.Employee>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.Id);
        }
    }
}

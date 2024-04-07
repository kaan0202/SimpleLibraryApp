using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Configurations.Person
{
    public class PersonConfiguration : IEntityTypeConfiguration<Domain.Entities.Person>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(x => x.Id);

            builder.HasOne(x=>x.Address).WithOne(x=>x.Person).HasForeignKey<Domain.Entities.Person>(x=>x.AddressId);
            builder.HasOne(x => x.Basket).WithOne(x => x.Person).HasForeignKey<Domain.Entities.Person>(x => x.BasketId);
        }
    }
}

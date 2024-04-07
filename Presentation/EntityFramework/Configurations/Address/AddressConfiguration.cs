using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Configurations.Address
{
    public class AddressConfiguration : IEntityTypeConfiguration<Domain.Entities.Address>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Person)
             .WithOne(x => x.Address)
             .HasForeignKey<Domain.Entities.Address>(x => x.PersonId);

            builder.HasOne(x => x.NeighboorHood)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.NeighboorHoodId);
                
            
        }
    }
}

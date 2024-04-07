using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Configurations.Basket
{
    public class BasketConfiguration : IEntityTypeConfiguration<Domain.Entities.Basket>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Basket> builder)
        {
            builder.ToTable("Baskets");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Person)
                .WithOne(x => x.Basket)
                .HasForeignKey<Domain.Entities.Basket>(x => x.PersonId);
        }
    }
}

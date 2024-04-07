using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Configurations.NeighboorHood
{
    public class NeighboorHoodConfiguration : IEntityTypeConfiguration<Domain.Entities.NeighboorHood>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.NeighboorHood> builder)
        {
            builder.ToTable("NeighboorHoods");
            builder.HasKey(x => x.Id);
        }
    }
}

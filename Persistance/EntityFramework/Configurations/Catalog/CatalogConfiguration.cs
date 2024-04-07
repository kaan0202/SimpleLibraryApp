using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Configurations.Catalog
{
    public class CatalogConfiguration : IEntityTypeConfiguration<Domain.Entities.Catalog>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Catalog> builder)
        {
            builder.ToTable("Catalogs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CatalogName).IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Configurations.Language
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Domain.Entities.Language>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Language> builder)
        {
            builder.ToTable("Languages");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Catalog).WithOne(x => x.Language).HasForeignKey<Domain.Entities.Language>(x => x.CatalogId);
        }
    }
}

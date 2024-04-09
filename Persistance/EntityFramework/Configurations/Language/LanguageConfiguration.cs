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
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);

            builder.HasMany(x => x.Catalog).WithOne(x => x.Language).HasForeignKey(x => x.LanguageId);
        }
    }
}

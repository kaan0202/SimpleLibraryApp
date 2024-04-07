using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Configurations.Author
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Domain.Entities.Author>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.BirthDay).IsRequired();
            builder.Property(x => x.Name).IsRequired();



        }
    }
}

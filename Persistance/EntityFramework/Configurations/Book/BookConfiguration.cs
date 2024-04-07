using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Configurations.Book
{
    public class BookConfiguration : IEntityTypeConfiguration<Domain.Entities.Book>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Book> builder)
        {
            builder.ToTable("Books");
           builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId);

            builder.HasOne(x =>x.Catalog)
                .WithMany(x => x.Books)
                .HasForeignKey(x =>x.CatalogId);

            builder.HasOne(x => x.Language)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.LanguageId);




        }
    }
}

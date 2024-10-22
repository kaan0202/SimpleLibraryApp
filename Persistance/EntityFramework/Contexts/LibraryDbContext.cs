using Domain.Entities;
using Domain.Entities.Common;
using Domain.Entities.File;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Contexts
{
    public class LibraryDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public LibraryDbContext(DbContextOptions options):base(options)
        {
            
        }

        public LibraryDbContext()
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<NeighboorHood> NeighboorHoods { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Domain.Entities.File.File> Files { get; set; }
        public DbSet<AuthorImageFile> AuthorImageFiles { get; set; }

        public DbSet<BookImageFile> BookImageFiles { get; set; }



       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                      _ => DateTime.Now
                };
            }
          
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

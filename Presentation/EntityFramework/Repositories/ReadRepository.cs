using Application.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistance.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityFramework.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity,new()
    {
        private readonly LibraryDbContext _context;
        public ReadRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter, bool tracking)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                 query = Table.AsNoTracking();
               
            return await query.AnyAsync(filter);    


        }

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking)
                query = Table.AsNoTracking();

            return query;
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
                if(!tracking)
                query = Table.AsNoTracking();

            return await query.FirstOrDefaultAsync(data => data.Id == id);

        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking)
                query = Table.AsNoTracking();

            return await query.FirstAsync(filter);
        }

        public  IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking)
                query = Table.AsNoTracking();
            return  query.Where(filter);
        }
    }
}

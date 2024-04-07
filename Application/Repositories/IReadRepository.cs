using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IReadRepository<TEntity>:IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> filter, bool tracking = true);
        IQueryable<TEntity> GetAll(bool tracking = true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true);
        Task<TEntity> GetByIdAsync(int id, bool tracking = true);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true);
    }
}

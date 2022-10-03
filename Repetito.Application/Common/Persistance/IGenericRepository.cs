using Repetito.Domain;
using Repetito.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repetito.Application.Common.Persistance
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<Result<T>> Add(T entity);
        Task<Result> AddRange(IEnumerable<T> entities);

        Result DeleteEntity(T entity);
        Task<Result> DeleteById(long id);
        Result Update(T entity);
        Task<Result<T>> GetById(long id);

        Task<Result<IList<T>>> ListAsync(Expression<Func<T, bool>> expression = null, List<string> includes = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int count = 0, bool trackChanges = false);

        Task<Result<T>> GetByExpression(Expression<Func<T, bool>> expression, List<string> includes = null, bool trackChanges = false);
    }
}

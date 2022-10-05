using Repetito.Domain;
using Repetito.Domain.Entities;
using System.Linq.Expressions;

namespace Repetito.Application.Common.Persistance;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> Add(T entity);
    Task AddRange(IEnumerable<T> entities);

    Result DeleteEntity(T entity);
    Task<Result> DeleteById(long id);
    Result Update(T entity);
    Task<T> GetById(Guid id);

    Task<IList<T>> ListAsync(Expression<Func<T, bool>> expression = null, List<string> includes = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int count = 0, bool trackChanges = false);

    Task<T> GetByExpression(Expression<Func<T, bool>> expression, List<string> includes = null, bool trackChanges = false);
}

using Microsoft.EntityFrameworkCore;
using Repetito.Application.Common.Persistance;
using Repetito.Domain;
using Repetito.Domain.Entities;
using System.Linq.Expressions;

namespace Repetito.Infrastructure.Persistance
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _dbSet = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            var addedEntity = await _dbSet.AddAsync(entity);

            return addedEntity.Entity;
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public Result DeleteEntity(T entity)
        {
            try
            {
                var result = _dbSet.Remove(entity);
                return Result.Succeed();
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result> DeleteById(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
                return DeleteEntity(entity);

            return Result.Fail("NotFound");

        }
        public Result Update(T entity)
        {
            try
            {
                var result = _dbSet.Update(entity);
                return Result.Succeed();
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }
        public async Task<T> GetById(Guid id)
        {
            var foundEntity = await _dbSet.FindAsync(id);

            return foundEntity;
        }

        public async Task<IList<T>> ListAsync(Expression<Func<T, bool>> expression = null, string includes = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int count = 0, bool trackChanges = false)
        {
            IQueryable<T> query = _dbSet;

            var includesList = includes?.Split(", ").ToList();
            includesList?.ForEach(x => query.Include(x));

            if (expression != null)
                query = query.Where(expression);

            if (orderBy != null)
                query = orderBy(query);

            if (count > 0)
                query = query.Take(count);

            var result = trackChanges ? await query.ToListAsync() : await query.AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<T> GetByExpression(Expression<Func<T, bool>> expression, string? includes, bool trackChanges = false)
        {
            IQueryable<T> query = _dbSet;

            var includesList = includes?.Split(", ").ToList();

            if (includesList != null)
            {
                query = includesList.Aggregate(query, (current, includesList) => current.Include(includesList));
            }

            var item = trackChanges ? await query.FirstOrDefaultAsync(expression) : await query.AsNoTracking().FirstOrDefaultAsync(expression);

            return item;
        }


        
    }
}

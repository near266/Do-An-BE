using System.Linq.Expressions;
using WebApi.Application.Models;

namespace WebApi.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        public Task AddAsync(T entity);
        public Task AddRangeAsync(IEnumerable<T> entities);
        public Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        public Task<bool> AnyAsync();
        public Task<int> CountAsync(Expression<Func<T, bool>> filter);
        public Task<int> CountAsync();
        public Task<T> GetByIdAsync(object id);
        public Task<List<T>> ToList();
        public Task<Pagination<T>> GetAsync(
           Expression<Func<T, bool>> filter,
           int pageIndex,
           int pageSize);
        public Task<Pagination<T>> ToPagination(int pageIndex, int pageSize);
        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        public void Update(T entity);
        public void UpdateRange(IEnumerable<T> entities);
        public void Delete(T entity);
        public void DeleteRange(IEnumerable<T> entities);
        public Task Delete(object id);
    }
}

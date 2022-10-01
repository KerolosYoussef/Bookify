using System.Linq.Expressions;
using Bookify.Helpers;
using Microsoft.EntityFrameworkCore.Query;

namespace Bookify.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);

        T GetById(int id, Expression<Func<T, object>>[] includes,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includeFunction = null);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(
            Expression<Func<T,object>>[] includes,
            Expression<Func<T,object>> orderBy = null,
            string orderByType = "Ascending",
            int take = 50
        );

        T Find(Expression<Func<T, bool>> criteria);
        T Find(Expression<Func<T, bool>> criteria, string[] includes);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria);
        IEnumerable<T> FindAll(
            Expression<Func<T, bool>> criteria,
            Expression<Func<T,object>>[] includes,
            PaginationFilters paginationFilters = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Expression<Func<T, object>> orderBy = null,
            string orderByType = "Ascending"
        );

        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        T Update(T entity);

        IEnumerable<T> UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        public void DeleteRange(IEnumerable<T> entities);

        int Count();
        int Count(Expression<Func<T, bool>> criteria);

    }
}

using System.Linq.Expressions;
using Bookify.Data;
using Bookify.Helpers;
using Bookify.Interfaces;
using Bookify.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Bookify.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetById(int id, Expression<Func<T, object>>[] includes,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includeFunction = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if(includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (includeFunction != null)
            {
                query = includeFunction(query);
            }
            
            return query.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public IEnumerable<T> GetAll(
            Expression<Func<T,object>>[] includes,
            Expression<Func<T, object>> orderBy = null,
            string orderByType = "Ascending",
            int take = 50
        )
        {
            IQueryable<T> query = _context.Set<T>();
            foreach(var criteria in includes)
                query = query.Include(criteria);

            if (orderBy != null)
            {
                if(orderByType == null || orderByType == OrderByTypes.OrderByAscending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.Take(take).ToList();
        }

        public T Find(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().SingleOrDefault(criteria);
        }

        public T Find(Expression<Func<T, bool>> criteria, string[] includes)
        {
            var query = _context.Set<T>();

            query = AddIncludesToQuery(query, includes);

            return query.SingleOrDefault(criteria);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Where(criteria).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria,Expression<Func<T,object>>[] includes,
            PaginationFilters paginationFilters = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includeFunction = null,
            Expression<Func<T, object>> orderBy = null,
            string orderByType = "Ascending"
        )
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);
            // Add Includes
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            

            if (includeFunction != null)
            {
                query = includeFunction(query);
            }
            
            if (orderBy != null)
            {
                if(orderByType == null || orderByType == OrderByTypes.OrderByAscending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }
            
            // check for pagination
            if (paginationFilters != null)
            {
                query = query.Skip((paginationFilters.PageNumber - 1) * paginationFilters.PageSize).Take(paginationFilters.PageSize);
            }

            return query.ToList();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return entities;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);
            return entities;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        
        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Where(criteria).Count();
        }

        private DbSet<T> AddIncludesToQuery(DbSet<T> query, string[] includes)
        {
            foreach (var include in includes)
            {
                query.Include(include);
            }

            return query;
        }
    }
}

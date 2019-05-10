using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WACore.Data.Core.Interfaces;

namespace WACore.Data.Core
{
    // with this there is no need for factory implementation
    // only one class for repository that will allow every type from the db
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        #region Get

        public virtual async Task<T> GetById(Guid id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual IQueryable<T> GetAllQueryable()
        {
            return Context.Set<T>();
        }

        public virtual IEnumerable<T> GetAllEnumerable()
        {
            return Context.Set<T>().ToList();
        }

        #endregion

        #region Add

        public virtual async Task Add(T entity, bool save = false)
        {
            await Context.Set<T>().AddAsync(entity);
            if(save)
                Save();
        }

        public virtual async Task Add(IList<T> entities, bool save = false)
        {
            await Context.Set<T>().AddRangeAsync(entities);
            if (save)
                Save();
        }

        #endregion

        #region Filter

        public virtual IList<T> Filter(Expression<Func<T, bool>> filterExpression)
        {
            return Context.Set<T>().Where(filterExpression).ToList();
        }

        #endregion

        #region Paging

        public virtual IQueryable<T> GetPage(out int total, int page = 0, int rows = 0, string orderBy = null, string orderDir = null, string includeProperties = "")
        {
            IQueryable<T> query = Context.Set<T>();
            return GetPageCommon(out total, query, page, rows, orderBy, orderDir, includeProperties);
        }

        public virtual IQueryable<T> GetPageCommon(out int total, IQueryable<T> query, int page, int rows, string orderBy = null, string orderDir = null, string includeProperties = "")
        {
            total = query.Count();

            foreach(var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if(rows > 0)
            {
                query = query.OrderBy($"{orderBy} {orderDir}").Skip((page * rows) - rows).Take(rows);
            }
            return query;
        }

        #endregion
        private void Save()
        {
            try
            {
                Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var exception = ex;
            }
        }
    }
}

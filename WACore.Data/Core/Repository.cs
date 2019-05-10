﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        #region Add/Update

        public virtual async Task Add(T entity, bool save = true)
        {
            Context.Set<T>().Add(entity);
            if(save)
                await Save();
        }

        public virtual async Task Add(IEnumerable<T> entities, bool save = true)
        {
            Context.Set<T>().AddRange(entities);
            if (save)
                await Save();
        }

        public virtual async Task<int> Update(T entity, bool save = true)
        {
            Context.Entry(entity).State = EntityState.Modified;

            if (save)
            {
                return await Save();
            }
            return 0;
        }

        #endregion

        #region Delete

        public virtual async Task Delete(T entity, bool save = true)
        {
            Context.Set<T>().Remove(entity);

            if (save)
                await Save();

        }

        public virtual async Task Delete(IEnumerable<T> entities, bool save = true)
        {
            Context.Set<T>().RemoveRange(entities);

            if (save)
                await Save();
        }

        public virtual async Task Delete(Expression<Func<T, bool>> filterExpression, bool save = true)
        {
            await Delete(Filter(filterExpression), save);
        }

        #endregion

        #region Filter

        public virtual IList<T> Filter(Expression<Func<T, bool>> filterExpression)
        {
            return Context.Set<T>().Where(filterExpression).ToList();
        }

        #endregion

        private async Task<int> Save()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var exception = ex;
            }
            return 0;
        }
    }
}

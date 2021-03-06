﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WACore.Data.Core.Interfaces
{
    //this will serve as our all in one repository
    public interface IRepository<T>
    {
        Task<T> GetById(Guid id);
        IQueryable<T> GetAllQueryable();
        IEnumerable<T> GetAllEnumerable();
        Task Add(T entity, bool save = true);
        Task Add(IEnumerable<T> entity, bool save = true);
        Task<int> Update(T entity, bool save = true);
        Task Delete(T entity, bool save = true);
        Task Delete(IEnumerable<T> entities, bool save = true);
        Task Delete(Expression<Func<T, bool>> filterExpression, bool save = true);
        IList<T> Filter(Expression<Func<T, bool>> filterExpression);

        //paging
        IQueryable<T> GetPage(out int total, int page = 0, int rows = 0, string orderBy = null, string orderDir = null, string includeProperties = "");
        IQueryable<T> GetPageCommon(out int total, IQueryable<T> query, int page, int rows, string orderBy = null, string orderDir = null, string includeProperties = "");
    }
}

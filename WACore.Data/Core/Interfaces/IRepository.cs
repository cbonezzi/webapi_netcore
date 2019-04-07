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
        Task Add(T entity, bool save = false);
        Task Add(IList<T> entity, bool save = false);
        IList<T> Filter(Expression<Func<T, bool>> filterExpression);
    }
}

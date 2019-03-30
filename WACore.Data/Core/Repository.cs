using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        #endregion

        private void Save()
        {
            Context.SaveChangesAsync();
        }
    }
}

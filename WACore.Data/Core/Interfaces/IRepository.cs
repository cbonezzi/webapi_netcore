using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WACore.Data.Core.Interfaces
{

    //this will serve as our all in one repository
    public interface IRepository<T>
    {
        Task<T> GetById(Guid id);
    }
}

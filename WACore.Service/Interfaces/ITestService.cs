using System.Collections.Generic;
using System.Threading.Tasks;
using WACore.Data.Model;
using WACore.Dto.Users;

namespace WACore.Service.Interfaces
{
    public interface ITestService
    {
        //consider outputing a dto instead of a entity. I think this will help with decoupling.
        //by returning a dto we are more flexible
        Task<UserCred> Test1(string id);
        Task Test2(IList<UserDto> user, bool save = false);
        Task<UserDto> Test3(string email);
        Task<IList<UserDto>> Test4();

    }
}

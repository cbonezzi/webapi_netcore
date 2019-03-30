using System.Threading.Tasks;
using WACore.Data.Model;

namespace WACore.Service.Interfaces
{
    public interface ITestService
    {
        Task<UserCred> Test1(string id);
        Task<UserInfo> Test2(string id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using WACore.Data.Model;
using WACore.Dto.Dtos;

namespace WACore.Service.Interfaces
{
    public interface IUserService
    {
        //consider outputing a dto instead of a entity. I think this will help with decoupling.
        //by returning a dto we are more flexible
        Task<UserDto> GetUserById(string id);
        Task Add(IList<UserDto> user, bool save = false);
        UserDto GetUserByEmail(string email);
        Task<int> UpdateUser(UserDto user, bool save = false);
		Task<IList<UserDto>> Test4(int page, int rows);

	}
}

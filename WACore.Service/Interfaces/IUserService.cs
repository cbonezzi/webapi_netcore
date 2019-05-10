﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WACore.Data.Model;
using WACore.Dto.Users;

namespace WACore.Service.Interfaces
{
    public interface IUserService
    {
        //consider outputing a dto instead of a entity. I think this will help with decoupling.
        //by returning a dto we are more flexible
        Task<UserDto> GetUserById(string id);
        Task Add(IList<UserDto> user, bool save = false);
        UserDto GetUserByEmail(string email);
        Task<IList<UserDto>> Test4();
        Task<int> UpdateUser(UserDto user, bool save = false);

    }
}
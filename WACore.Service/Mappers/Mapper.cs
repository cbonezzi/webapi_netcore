using System;
using WACore.Data.Model;
using WACore.Dto.Users;

namespace WACore.Service.Mappers
{
    public class Mapper : IMappers<UserDto, UserCred>
    {
        public UserCred Map(UserDto user)
        {
            return new UserCred
            {
                UserId = new Guid(user.UserId),
                Expire = user.Expire,
                Username = user.Username
            };
        }
    }
}

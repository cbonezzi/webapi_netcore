using System;
using WACore.Data.Model;
using WACore.Dto.Dtos;
using WACore.Service.Mappers.Interfaces;

namespace WACore.Service.Mappers
{
    public class MapperToUserCred : IMappers<UserDto, UserCred>
    {
        public UserCred Map(UserDto user)
        {
            return new UserCred
            {
                Expire = user.Expire,
                Username = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                UserId = string.IsNullOrEmpty(user.UserId) ? Guid.Empty : new Guid(user.UserId),
                Phone = user.Phone.Replace(" ", ""),
                Age = user.Age
            };
        }
    }
}

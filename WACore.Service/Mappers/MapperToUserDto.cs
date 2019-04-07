using WACore.Data.Model;
using WACore.Dto.Users;
using WACore.Service.Mappers.Interfaces;

namespace WACore.Service.Mappers
{
    public class MapperToUserDto : IMappers<UserCred, UserDto>
    {
        public UserDto Map(UserCred user)
        {
            return new UserDto
            {
                UserId = user.UserId.ToString(),
                Expire = user.Expire,
                Username = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Phone = user.Phone.Replace(" ", "")
            };
        }
    }
}

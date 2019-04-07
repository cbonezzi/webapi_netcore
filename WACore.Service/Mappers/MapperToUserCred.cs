using WACore.Data.Model;
using WACore.Dto.Users;
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
                Phone = user.Phone.Replace(" ", "")
            };
        }
    }
}

using System;
using WACore.Data.Model;
using WACore.Data.Core.Interfaces;
using WACore.Service.Interfaces;
using System.Threading.Tasks;
using WACore.Dto.Users;
using WACore.Service.Mappers.Interfaces;
using System.Collections.Generic;

namespace WACore.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserCred> _userRepository;
        private readonly IRepository<UserInfo> _userInfoRepository;
        private IMappers<UserDto, UserCred> _mapperToEntity;
        private IMappers<UserCred, UserDto> _mapperToDto;

        //injecting repositories and mappers for use in service layer
        public UserService(
            IRepository<UserCred> userRepository, 
            IRepository<UserInfo> userInfoRepository, 
            IMappers<UserDto, UserCred> mapperToEntity, 
            IMappers<UserCred, UserDto> mapperToDto)
        {
            _userRepository = userRepository;
            _userInfoRepository = userInfoRepository;
            _mapperToEntity = mapperToEntity;
            _mapperToDto = mapperToDto;
        }

        public async Task<UserDto> GetUserById(string id)
        {
            var result = await _userRepository.GetById(new Guid(id));
            if(result != null)
                return _mapperToDto.Map(result);
            return null;
        }

        public async Task Add(IList<UserDto> users, bool save = false)
        {
            var userEntities = new List<UserCred>();
            foreach(var item in users)
            {
                userEntities.Add(_mapperToEntity.Map(item));
            }

            await _userRepository.Add(userEntities, true);
        }

        public async Task<int> UpdateUser(UserDto user, bool save = false)
        {
            var result = await _userRepository.Update(_mapperToEntity.Map(user), true);
            return result;
        }

        public UserDto GetUserByEmail(string email)
        {
            var result = _userRepository.Filter(x => x.Username == email);
            if (result.Count == 1)
                return _mapperToDto.Map(result[0]);
            return null;
        }

        public async Task<IList<UserDto>> Test4()
        {
            var result = _userRepository.GetAllEnumerable();
            var otherResult = _userInfoRepository.GetAllEnumerable();
            var userList = new List<UserDto>();
            foreach(var user in result)
            {
                userList.Add(_mapperToDto.Map(user));
            }
            return userList;
        }

    }
}

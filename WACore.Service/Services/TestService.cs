using System;
using WACore.Data.Model;
using WACore.Data.Core.Interfaces;
using WACore.Service.Interfaces;
using System.Threading.Tasks;
using WACore.Dto.Users;
using WACore.Service.Mappers.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace WACore.Service.Services
{
    public class TestService : ITestService
    {
        private readonly IRepository<UserCred> _userRepository;
        private readonly IRepository<UserInfo> _userInfoRepository;
        private IMappers<UserDto, UserCred> _mapperToEntity;
        private IMappers<UserCred, UserDto> _mapperToDto;

        //injecting repositories and mappers for use in service layer
        public TestService(IRepository<UserCred> userRepository, IRepository<UserInfo> userInfoRepository, IMappers<UserDto, UserCred> mapperToEntity, IMappers<UserCred, UserDto> mapperToDto)
        {
            _userRepository = userRepository;
            _userInfoRepository = userInfoRepository;
            _mapperToEntity = mapperToEntity;
            _mapperToDto = mapperToDto;
        }

        public async Task<UserCred> Test1(string id)
        {
            var result = await _userRepository.GetById(new Guid(id));
            return result;
        }

        public async Task Test2(IList<UserDto> users, bool save = false)
        {
            var userEntities = new List<UserCred>();
            foreach(var item in users)
            {
                userEntities.Add(_mapperToEntity.Map(item));
            }

            await _userRepository.Add(userEntities, true);
        }

        public async Task<UserDto> Test3(string email)
        {
            var result = _userRepository.Filter(x => x.Username == email);
            if (result.Count == 1)
                return _mapperToDto.Map(result[0]);
            return null;
        }

        public async Task<IList<UserDto>> Test4(int page, int rows)
        {
            Expression<Func<UserCred, bool>> where = g => g.Expire == "00000001";

            var query = _userRepository.GetAllQueryable().Where(where);

            var result = _userRepository.GetPageCommon(out var total, query, page, rows);
            var userList = new List<UserDto>();
            foreach(var user in result)
            {
                userList.Add(_mapperToDto.Map(user));
            }
            return userList;
        }
    }
}

using System;
using WACore.Data.Model;
using WACore.Data.Core.Interfaces;
using WACore.Service.Interfaces;
using System.Threading.Tasks;

namespace WACore.Service.Services
{
    public class TestService : ITestService
    {
        private readonly IRepository<UserCred> _userRepository;
        private readonly IRepository<UserInfo> _userInfoRepository;

        //injecting repositories for use in service layer
        public TestService(IRepository<UserCred> userRepository, IRepository<UserInfo> userInfoRepository)
        {
            _userRepository = userRepository;
            _userInfoRepository = userInfoRepository;
        }

        public async Task<UserCred> Test1(string id)
        {
            var result = await _userRepository.GetById(new Guid(id));
            return result;
        }

        public async Task<UserInfo> Test2(string id)
        {
            var result = await _userInfoRepository.GetById(new Guid(id));
            return result;
        }
    }
}

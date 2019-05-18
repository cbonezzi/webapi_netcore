using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WACore.Dto.Dtos;
using WACore.Service.Interfaces;

namespace WACore.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOptions<AppSettings> _options;

        //injecting testService and AppSettings for use in controller.
        public UserController(IUserService userService, IOptions<AppSettings> options)
        {
            _userService = userService;
            _options = options;
        }

        // GET api/user
        [Route("users/")]
        public async Task<IList<UserDto>> Get()
        {
            var result = await _userService.Test4(1, 10);
            return result;
        }

        // GET api/user/12345-67890-12345678-9012345
        [Route("{id}")]
        public ActionResult<UserDto> GetSingleUser(Guid id)
        {
            var result = _userService.GetUserById(id.ToString()).Result;
            return result;
        }

        // GET api/user/email/email@address.com
        [Route("email/{email}")]
        public UserDto GetUserByEmail(string email)
        {
            var result = _userService.GetUserByEmail(email);
            return result;
        }

        // POST api/user/AddUsers
        [Route("AddUsers/")]
        public void Post([FromBody] IList<UserDto> user)
        {
            _userService.Add(user);
        }

        [HttpPost]
        public void PostUser([FromBody] UserDto user)
        {
            var list = new List<UserDto>();
            list.Add(user);
            _userService.Add(list);
        }

        // PUT api/user/UpdateUser
        [Route("UpdateUser/")]
        public int PutUser([FromBody] UserDto user)
        {
            var result = _userService.UpdateUser(user).Result;
            return result;
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

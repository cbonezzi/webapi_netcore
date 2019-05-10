using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WACore.Dto.Users;
using WACore.Service.Interfaces;

namespace WACore.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IOptions<AppSettings> _options;

        //injecting testService and AppSettings for use in controller.
        public ValuesController(ITestService testService, IOptions<AppSettings> options)
        {
            _testService = testService;
            _options = options;
        }

        // GET api/values
        [Route("users/")]
        public async Task<IList<UserDto>> Get()
        {
            var result = await _testService.Test4(1, 10);
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(string id)
        {
            var result = _testService.Test1(id).Result;

            return new UserDto
            {
                UserId = result.UserId.ToString(),
                Expire = result.Expire,
                Firstname = result.Firstname,
                Lastname = result.Lastname,
                Phone = result.Phone,
                Username = result.Username
            };
        }

        // GET api/values/pajuo?email=email
        //[Route("pajuo/")]
        //public async Task<UserDto> Get(string email)
        //{
        //    var result = await _testService.Test3(email);
        //    return result;
        //}

        //[Route("allusers/")]
        //public async Task<IList<UserDto>> Get()
        //{
        //    var result = await _testService.Test4();
        //    return result;
        //}

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody] IList<UserDto> user)
        //{
        //    _testService.Test2(user, true);
        //}

        [HttpPost]
        public void Post([FromForm] UserDto user)
        {
            var list = new List<UserDto>();
            list.Add(user);
            _testService.Test2(list, true);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

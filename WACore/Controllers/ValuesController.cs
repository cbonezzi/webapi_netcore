using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WACore.Service.Interfaces;

namespace WACore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ITestService _testService;

        //injecting testService for use in controller.
        public ValuesController(ITestService testService)
        {
            _testService = testService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //only for testing purposes.
            var result = _testService.Test1("350ABF77-B945-4B94-A6A4-3177BDEDD5D8").Result;
            return new string[] { result.UserId.ToString(), result.Expire, result.Username };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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

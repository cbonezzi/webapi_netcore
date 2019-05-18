using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WACore.Dto.Dtos;
using WACore.Service.Interfaces;

namespace WACore.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class NameController : ControllerBase
	{
		private readonly INameService _nameService;
		private readonly IOptions<AppSettings> _options;

		public NameController(INameService nameService, IOptions<AppSettings> options)
		{
			_nameService = nameService;
			_options = options;
		}

		[Route("random/")]
		public NamesDto Get()
		{
			var result = _nameService.GetRandomName();
			return result;
		}

		[Route("add/")]
		public void Post([FromBody] NamesDto name)
		{
			_nameService.AddName(name);
		}

		[Route("add/names/")]
		public void Post([FromBody] IList<NamesDto> names)
		{
			_nameService.AddNames(names);
		}

		[Route("update/")]
		public int Put([FromBody] NamesDto name)
		{
			var result = _nameService.UpdateName(name).Result;
			return result;
		}
    }
}
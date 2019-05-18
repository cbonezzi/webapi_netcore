using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WACore.Dto.Dtos;

namespace WACore.Service.Interfaces
{
	public interface INameService
	{
		NamesDto GetRandomName();
		Task AddName(NamesDto name);
		Task AddNames(IList<NamesDto> names);
		Task<int> UpdateName(NamesDto user, bool save = true);
	}
}

using WACore.Data.Model;
using WACore.Dto.Dtos;
using WACore.Service.Mappers.Interfaces;

namespace WACore.Service.Mappers
{
	public class MapperToHumanDto : IMappers<HumanNames, NamesDto>
	{
		public NamesDto Map(HumanNames name)
		{
			return new NamesDto
			{
				Firstname = name.Firstname,
				Lastname = name.Lastname,
				Sex = name.Sex
			};
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using WACore.Data.Model;
using WACore.Dto.Dtos;
using WACore.Service.Mappers.Interfaces;

namespace WACore.Service.Mappers
{
	public class MapperToHumanName : IMappers<NamesDto, HumanNames>
	{
		public HumanNames Map(NamesDto name)
		{
			return new HumanNames
			{
				Firstname = name.Firstname,
				Lastname = name.Lastname,
				Sex = name.Sex
			};
		}
	}
}

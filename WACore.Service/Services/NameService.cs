using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WACore.Data.Core.Interfaces;
using WACore.Data.Model;
using WACore.Dto.Dtos;
using WACore.Service.Interfaces;
using WACore.Service.Mappers.Interfaces;

namespace WACore.Service.Services
{
	public class NameService : INameService
	{
		private readonly IRepository<HumanNames> _humanNamesRepository;
		private IMappers<NamesDto, HumanNames> _mapperToEntity;
		private IMappers<HumanNames, NamesDto> _mapperToDto;

		public NameService(
			IRepository<HumanNames> humanNamesRepository,
			IMappers<NamesDto, HumanNames> mapperToEntity,
			IMappers<HumanNames, NamesDto> mapperToDto)
		{
			_humanNamesRepository = humanNamesRepository;
			_mapperToEntity = mapperToEntity;
			_mapperToDto = mapperToDto;

		}

		public async Task AddName(NamesDto name)
		{
			if(name != null)
			{
				await _humanNamesRepository.Add(_mapperToEntity.Map(name));
			}
		}

		public async Task AddNames(IList<NamesDto> names)
		{
			var namesEntities = new List<HumanNames>();
			foreach(var item in names)
			{
				namesEntities.Add(_mapperToEntity.Map(item));
			}
			await _humanNamesRepository.Add(namesEntities);
		}

		public NamesDto GetRandomName()
		{
			var result = _humanNamesRepository.GetAllQueryable().ToList();

			var count = result.Count();
			int index = new Random().Next(count);

			var name = result.Skip(index).FirstOrDefault();

			if(name != null)
			{
				return _mapperToDto.Map(name);
			}
			return null;
		}

		public async Task<int> UpdateName(NamesDto name, bool save = true)
		{
			var result = await _humanNamesRepository.Update(_mapperToEntity.Map(name));
			return result;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;

namespace Application.Services
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _repository;

        public AreaService(IAreaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<string>> GetAllAsync()
        {
            var areas = await _repository.GetAllAsync();
            return areas.Select(a => a.Name).ToList();
        }
    }
}

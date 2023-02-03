using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Data.Repositories
{
    public interface IUnitRepository
    {
        public Task CreateAsync(List<Unit> units);

        public Task<List<Unit>> GetAllAsync();

        public List<int> FilterNewProductIds(List<int> ids);

        public Task DeleteOldAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Data.Repositories
{
    public interface IAreaRepository
    {
        public Task<List<Area>> GetAllAsync();

        public Task UpdateAsync(List<Area> areas);
    }
}

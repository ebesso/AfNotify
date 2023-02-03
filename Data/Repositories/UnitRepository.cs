using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly DatabaseContext _context;

        public UnitRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(List<Unit> units)
        {
            await _context.Units.AddRangeAsync(units);
            await _context.SaveChangesAsync();
        }

        public Task DeleteOldAsync()
        {
            throw new NotImplementedException();
        }

        public List<int> FilterNewProductIds(List<int> ids)
        {
            var dbIds = _context.Units.Select(u => u.ProductId).ToHashSet();
            return ids.FindAll(id => !dbIds.Contains(id));
        }

        public async Task<List<Unit>> GetAllAsync()
        {
            return await _context.Units.ToListAsync();
        }
    }
}

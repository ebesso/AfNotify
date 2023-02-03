using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly DatabaseContext _context;

        public AreaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Area>> GetAllAsync()
        {
            return await _context.Areas.Include(a => a.Notifications).ToListAsync();
        }

        public async Task UpdateAsync(List<Area> areas)
        {
            _context.UpdateRange(areas);
            await _context.SaveChangesAsync();
        }
    }
}

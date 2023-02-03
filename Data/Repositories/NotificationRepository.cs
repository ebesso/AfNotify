using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly DatabaseContext _context;

        public NotificationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Notification>> GetAllAsync()
        {
            return await _context.Notifications.Include(n => n.Areas).ToListAsync();
        }
    }
}

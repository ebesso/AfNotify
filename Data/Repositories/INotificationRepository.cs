using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Data.Repositories
{
    public interface INotificationRepository
    {
        public Task CreateAsync(Notification notification);

        public Task<List<Notification>> GetAllAsync();

        public Task DeleteAsync(int id);
    }
}

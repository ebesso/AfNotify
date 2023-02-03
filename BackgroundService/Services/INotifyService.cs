using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace BackgroundWorker.Services
{
    public interface INotifyService
    {
        public Task SendNotification(List<Unit> units);
    }
}

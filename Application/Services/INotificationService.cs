using System;
using System.Threading.Tasks;
using Application.Dtos;

namespace Application.Services
{
    public interface INotificationService
    {
        public Task CreateAsync(CreateNotificationDto dto);
    }
}

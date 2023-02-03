using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services;
using Core.Entities;
using Core.Enums;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BackgroundWorker.Services
{
    public class NotifyService : INotifyService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<NotifyService> _logger;

        public NotifyService(IServiceScopeFactory scopeFactory, ILogger<NotifyService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public async Task SendNotification(List<Unit> units)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var notificationRepository = scope.ServiceProvider.GetRequiredService<INotificationRepository>();

                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                var filterService = scope.ServiceProvider.GetRequiredService<IFilterService>();

                var notifications = await notificationRepository.GetAllAsync();

                foreach(var notification in notifications)
                {
                    var matched = filterService.Filter(units, notification);
                    emailService.SendEmail(notification.Email, matched);
                }


            }
        }
    }
}

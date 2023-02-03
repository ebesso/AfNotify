using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Core.Entities;
using Data.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly IFilterService _filterService;
        private readonly IEmailService _emailService;

        private readonly ILogger<NotificationService> _logger;

        public NotificationService(INotificationRepository notificationRepository, IAreaRepository areaRepository,
            IUnitRepository unitRepository, IFilterService filterService, IEmailService emailService,
            ILogger<NotificationService> logger)
        {
            _notificationRepository = notificationRepository;
            _areaRepository = areaRepository;
            _unitRepository = unitRepository;
            _filterService = filterService;
            _emailService = emailService;

            _logger = logger;
        }

        public async Task CreateAsync(CreateNotificationDto dto)
        {
            var areas = await _areaRepository.GetAllAsync();

            var notification = new Notification()
            {
                Apartment = dto.Apartment,
                Corridor = dto.Corridor,
                Email = dto.Email,
                FurnitureIncluded = dto.FurnitureIncluded,
                MaxRentalPeriods = dto.MaxRentalPeriods,
                MaxRooms = dto.MaxRentalPeriods,
                MaxSize = dto.MaxSize,
                MinSize = dto.MinSize,
                MinFloor = dto.MinFloor,
                MinRent = dto.MinRent,
                MaxRent = dto.MaxRent,
                MinRooms = dto.MinRooms,
                NovischPriority = dto.NovischPriority,
                Areas = dto.Areas.Count > 0 ? areas.Where(a => dto.Areas.Contains(a.Name)).ToList() : areas
            };

            await _notificationRepository.CreateAsync(notification);

            _logger.LogInformation("Saved notification");

            var units = await _unitRepository.GetAllAsync();

            var matched = _filterService.Filter(units, notification);

            _emailService.SendEmail(notification.Email, matched);
        }
    }
}

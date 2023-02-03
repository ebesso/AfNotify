using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/notification")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(CreateNotificationDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok();
        }
    }
}

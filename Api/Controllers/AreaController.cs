using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/area")]
    public class AreaController : Controller
    {
        private readonly IAreaService _service;
        public AreaController(IAreaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<string>>> GetAsync()
        {
            var areas = await _service.GetAllAsync();
            return Ok(areas);
        }
    }
}

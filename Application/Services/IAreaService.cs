using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IAreaService
    {
        public Task<List<string>> GetAllAsync();
    }
}

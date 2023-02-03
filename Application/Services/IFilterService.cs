using System;
using System.Collections.Generic;
using Core.Entities;

namespace Application.Services
{
    public interface IFilterService
    {
        public List<Unit> Filter(List<Unit> units, Notification notification);
    }
}

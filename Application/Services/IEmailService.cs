using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.Services
{
    public interface IEmailService
    {
        public void SendEmail(string email, List<Unit> units);
    }
}

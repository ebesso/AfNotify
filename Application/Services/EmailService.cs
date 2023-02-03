using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public void SendEmail(string email, List<Unit> units)
        {
            if (units.Count > 0)
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("", ""),
                    EnableSsl = true
                };

                smtpClient.Send("afnotifysender@gmail.com", email, "New listings that matches your filter",
                    string.Join(", ", units.Select(u => $"https://www.afbostader.se/lediga-bostader/bostadsdetalj/?obj={u.ProductId}&area={u.Area}&mode=0")));
                _logger.LogInformation($"Sent email to {email} about {string.Join(", ", units.Select(u => u.ProductId))}");
            }
        }
    }
}

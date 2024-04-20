using Microsoft.AspNetCore.Identity.UI.Services;

namespace ProjectMiniShop.Utility
{
    public class EmailService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            // Logic Email 

           return Task.CompletedTask;
        }
    }
}

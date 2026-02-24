using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace User_Service.Services.EmailSender
{
    // Implementer l'interface fournit par .net IEmailSneder
    public class EmailSenderHandler : IEmailSender
    {
        private IConfiguration config;
        public EmailSenderHandler(IConfiguration config)
        {
            this.config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Condifurer le message envoyer
            var message = new MailMessage()
            {
                From = new MailAddress(config["SmtpSettings:SenderEmail"]),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            // L'email de destinataire
            message.To.Add(email);

            using var smtp = new SmtpClient(config["SmtpSettings:Server"], int.Parse(config["SmtpSettings:Port"]))
            {
                Credentials = new NetworkCredential(
                config["SmtpSettings:SenderEmail"],
                config["SmtpSettings:Password"]
            ),
                EnableSsl = true
            };

            await smtp.SendMailAsync(message);
        }
    }
}

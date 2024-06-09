using System.Net.Mail;
using System.Net;

namespace BabbySitterAnytime.Services.EmailRepo
{
    public class SmtpEmailService : IEmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _fromEmail;
        private readonly string _emailPassword;

        public SmtpEmailService(string smtpServer, int smtpPort, string fromEmail, string emailPassword)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _fromEmail = fromEmail;
            _emailPassword = emailPassword;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true // Set to false if you are not sending HTML formatted emails
            };
            mailMessage.To.Add(to);

            using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort)
            {
                Credentials = new NetworkCredential(_fromEmail, _emailPassword),
                EnableSsl = true // Most SMTP servers require SSL nowadays
            })
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}

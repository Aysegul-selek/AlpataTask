using AlpataBusiness.Abstract;
using Castle.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpataBusiness.Concrete
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendWelcomeEmailAsync(string userEmail)
        {
            // Email gönderme işlemi burada gerçekleştirilecek
            // Örnek SMTP veya e-posta servisini kullanarak gönderim yapabilirsiniz
            // Örneğin:
            string subject = "Hoş Geldiniz!";
            string body = $"Merhaba, {userEmail}, uygulamamıza hoş geldiniz!";

            // Email gönderme kodu buraya eklenecek

            // Örneğin, SendGrid, SMTP veya başka bir e-posta servisi kullanabilirsiniz
            // Örnek SendGrid kullanımı:
            /*
            var apiKey = _configuration["SendGrid:ApiKey"];
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("your-email@example.com", "Your Name"),
                Subject = subject,
                PlainTextContent = body,
                HtmlContent = $"<strong>{body}</strong>",
            };
            msg.AddTo(new EmailAddress(userEmail));
            var response = await client.SendEmailAsync(msg);
            */
        }
    }
    }

// EmailService.cs

using AlpataAPI.Models;
using AlpataBusiness.Abstract;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

public class EmailService : IEmailService
{
    private readonly SendGridSettings _sendGridSettings;

    public EmailService(IOptions<SendGridSettings> sendGridSettings)
    {
        _sendGridSettings = sendGridSettings.Value;
    }

    public async Task SendWelcomeEmailAsync(string userEmail)
    {
        string subject = "Hoş Geldiniz!";
        string body = $"Merhaba, {userEmail}, uygulamamıza hoş geldiniz!";

        var client = new SendGridClient(_sendGridSettings.ApiKey);
        var msg = new SendGridMessage()
        {
            From = new EmailAddress(_sendGridSettings.FromEmail, _sendGridSettings.FromName),
            Subject = subject,
            PlainTextContent = body,
            HtmlContent = $"<strong>{body}</strong>",
        };
        msg.AddTo(new EmailAddress(userEmail));

        var response = await client.SendEmailAsync(msg);
        // Email gönderme işlemi sonucunu kontrol edebilirsiniz
    }
}

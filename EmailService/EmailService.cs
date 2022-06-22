using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace NotifierTestApp.EmailService;

public class EmailService : IEmailService
{
    public EmailService()
    {
    }

    public async Task Send(string to, string subject, string html, string from = null)
    {
        // create message
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(from ?? "test@outlook.com"));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html) { Text = html };

        // send email
        using var smtp = new SmtpClient();
        smtp.Connect("mail.outlook.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("test@outlook.com", "sdfdsaf");
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
    }
}
namespace NotifierTestApp.EmailService;

public interface IEmailService
{
    Task Send(string to, string subject, string html, string from = null);
}
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;


namespace ModelLibrary.EmailSender;

public class SmtpSender : IEmailSender
{
    private object key = new object();
    public IOptionsSnapshot<SmtpCredentials> _options { get; }
    public SmtpSender(IOptionsSnapshot<SmtpCredentials> options)
    {
        _options = options;
    }
    
    public void Send(InfoLetter _letter)
    {
        var _smtpCredentials = _options.Value;

        MailAddress from = new MailAddress(_letter.from, _letter.displayName);
        MailAddress to = new MailAddress(_letter.to);
            
        MailMessage m = new MailMessage(from, to);
        m.Subject = _letter.mSubject;
        m.Body = _letter.mBody;

        lock (key)
        {
            SmtpClient smtp = new SmtpClient(_smtpCredentials.Host, int.Parse(_smtpCredentials.Port));
            smtp.Credentials = new NetworkCredential(_smtpCredentials.UserName, _smtpCredentials.Password);
            smtp.EnableSsl = true;
        
            smtp.Send(m);
        }
        
    }
}
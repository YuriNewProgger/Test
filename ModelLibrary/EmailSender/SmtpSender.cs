using System.Net;
using System.Net.Mail;

namespace ModelLibrary.EmailSender;

public class SmtpSender : IEmailSender
{
    public void Send(string message)
    {
        MailAddress from = new MailAddress("asp2022@rodion-m.ru", "InterShop");
        MailAddress to = new MailAddress("yurok_89@mail.ru");
        
        MailMessage m = new MailMessage(from, to);
        m.Subject = "Status working";
        m.Body = "Intershop: Status-working";
        
        SmtpClient smtp = new SmtpClient("smtp.beget.com", 25);
        smtp.Credentials = new NetworkCredential("asp2022@rodion-m.ru", "aHGnOlz7");
        smtp.EnableSsl = true;
        smtp.Send(m);
    }
}
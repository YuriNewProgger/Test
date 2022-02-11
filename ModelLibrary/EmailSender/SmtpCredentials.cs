using System.Dynamic;

namespace ModelLibrary.EmailSender;

public class SmtpCredentials
{
/*"Host": "smtp.beget.com",
"UserName": "a@b.ru",
"Password": "000000"*/
    public string Host { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Port { get; set; }
    
}
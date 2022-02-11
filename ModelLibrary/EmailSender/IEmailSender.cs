using Microsoft.Extensions.Options;

namespace ModelLibrary.EmailSender;

public interface IEmailSender
{
    void Send(InfoLetter _letter);
    //void Send(string message);
}
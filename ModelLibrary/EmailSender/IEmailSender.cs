namespace ModelLibrary.EmailSender;

public interface IEmailSender
{
    void Send(string message);
}
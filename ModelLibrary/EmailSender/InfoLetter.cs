using System.Net.Mail;

namespace ModelLibrary.EmailSender;

public class InfoLetter
{
    public string from { get; set; }
    public string to { get; set; }
    public string displayName { get; set; }
    public string mSubject { get; set; }
    public string mBody { get; set; }
    

    // public InfoLetter(string _from, string _displayName, string _to, string? _titleLeter, string? _message)
    // {
    //     from = _from;
    //     to = _to;
    //     displayName = _displayName;
    //     mSubject = _titleLeter;
    //     mBody = _message;
    // }
    public InfoLetter()
    {}
}
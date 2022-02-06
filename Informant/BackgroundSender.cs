using System.Diagnostics;
using ModelLibrary.EmailSender;

namespace Informant;

public class BackgroundSender : BackgroundService
{
    private IEmailSender _sender { get; }

    public BackgroundSender(IEmailSender sender)
    {
        _sender = sender;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(60));
        var sw = Stopwatch.StartNew();
        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            _sender.Send($"Status: server working {sw.Elapsed} \nRAM - {(Process.GetProcessesByName("Informant")[0].WorkingSet64 / 1024).ToString()} KB");
        }
    }
}
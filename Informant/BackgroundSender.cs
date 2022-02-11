using System.Diagnostics;
using Microsoft.Extensions.Options;
using ModelLibrary.EmailSender;

namespace Informant;

public class BackgroundSender : BackgroundService
{
    public InfoLetter _letter { get; set; }
    private IServiceProvider _provider { get; }

    public BackgroundSender(IServiceProvider provider)
    {
        _provider = provider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));
        var sw = Stopwatch.StartNew();
        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                var sender = scope.ServiceProvider.GetRequiredService<IEmailSender>();
                _letter = new InfoLetter();
                _letter.from = "asp2022@rodion-m.ru";
                _letter.to = "yurok_89@mail.ru";
                _letter.displayName = "InterShop";
                _letter.displayName = "InterShop";
                _letter.mSubject = "Server status";
                _letter.mBody = $"Status: server working {sw.Elapsed} RAM - {(Process.GetProcessesByName("Informant")[0].WorkingSet64 / 1024).ToString()} KB";
                sender.Send(_letter);
            }
        }
    }
}
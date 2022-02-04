using Informant;
using ModelLibrary.EmailSender;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEmailSender, SmtpSender>();
builder.Services.AddHostedService<BackgroundSender>();


var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
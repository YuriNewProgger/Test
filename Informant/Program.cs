using System.Diagnostics;
using Informant;
using ModelLibrary.EmailSender;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<SmtpCredentials>(builder.Configuration.GetSection("SmtpCredentials"));

builder.Services.AddScoped<IEmailSender, SmtpSender>();
builder.Services.AddHostedService<BackgroundSender>();


var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
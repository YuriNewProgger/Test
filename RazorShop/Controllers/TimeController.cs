using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Time;

namespace RazorShop.Controllers;

public class TimeController : Controller
{
    private ITime utcCurrentTime { get; }
    public TimeController(ITime _time)
    {
        utcCurrentTime = _time;
    }
    // GET
    public IActionResult Index()
    {
        //time.GetTime();
        return View(utcCurrentTime);
    }
}
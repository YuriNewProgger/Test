using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Time;

namespace RazorShop.Controllers;

public class TimeController : Controller
{
    private IClock UtcCurrentClock { get; }
    public TimeController(IClock clock)
    {
        UtcCurrentClock = clock;
    }
    // GET
    public IActionResult Index()
    {
        //time.GetTime();
        return View(UtcCurrentClock);
    }
}
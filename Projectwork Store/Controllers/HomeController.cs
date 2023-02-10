using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projectwork_Store.Database;
using Projectwork_Store.Models;

namespace Projectwork_Store.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        using (StoreContext db = new StoreContext())
        {

            List<UserPurchase> ListPurchases = db.UserPurchases.ToList<UserPurchase>();
            List<Car> piuvenduti = db.Cars.Include(car => car.Category).Include(car => car.Sticker).ToList<Car>();

            ViewClassifica newview = new ViewClassifica();

            newview.Cars = piuvenduti;
            newview.Purchases = ListPurchases;

            return View("Index", newview);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;

namespace Projectwork_Store.Controllers
{
    public class ClientiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {

            return View();

        }
        public IActionResult ClientPurchase()
        {
            return View();
        }
    }
}

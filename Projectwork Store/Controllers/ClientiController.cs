using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;
using Projectwork_Store.Database;
using Projectwork_Store.Models;

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
        [HttpGet]
        public IActionResult ClientPurchase(int id)
        {
            using (StoreContext db = new StoreContext())
            {

                UserPurchase viewModel = new UserPurchase();

                return View("ClientPurchase", viewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClientPurchase(int id, UserPurchase newPurchase)
        {
            newPurchase.CarId = id;

            using (StoreContext db = new StoreContext())
            {
                Car carSelected = db.Cars
                    .Where(car => car.Id == id)
                    .FirstOrDefault();
                int newQuantity = carSelected.Quantity - newPurchase.Quantity;

                db.UserPurchases.Add(newPurchase);
                carSelected.Quantity = newQuantity;

                db.SaveChanges();

            }

            return RedirectToAction("Index");
        }
    }
}

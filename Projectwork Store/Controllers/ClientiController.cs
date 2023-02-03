using Microsoft.AspNetCore.Mvc;
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
        public IActionResult PurchaseConfirmed(int id)
        {
            using (StoreContext db = new StoreContext())
            {
                UserPurchase userSelected = db.UserPurchases
                    .Where(user => user.Id == id)
                    .FirstOrDefault();
                UserPurchase viewModel = userSelected;


                return View(viewModel);

            }
        }


        [HttpGet]
        public IActionResult ClientPurchase(int id)
        {
            using (StoreContext db = new StoreContext())
            {
                Car carSelected = db.Cars
                    .Where(car => car.Id == id)
                    .FirstOrDefault();
                CarClientPurchase viewModel = new CarClientPurchase();

                viewModel.Purchase = new UserPurchase();
                viewModel.Car = carSelected;

                return View("ClientPurchase", viewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClientPurchase(int id, CarClientPurchase newPurchase)
        {
            newPurchase.Purchase.CarId = id;

            using (StoreContext db = new StoreContext())
            {
                Car carSelected = db.Cars
                    .Where(car => car.Id == id)
                    .FirstOrDefault();
                int newQuantity = carSelected.Quantity - newPurchase.Purchase.Quantity;

                db.UserPurchases.Add(newPurchase.Purchase);
                carSelected.Quantity = newQuantity;

                db.SaveChanges();

            }

            return RedirectToAction("PurchaseConfirmed");
        }
    }
}

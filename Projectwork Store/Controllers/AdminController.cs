using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projectwork_Store.Database;
using Projectwork_Store.Models;

namespace Projectwork_Store.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            using(StoreContext db = new StoreContext())
            {
                List<Car> carsList = db.Cars.Include(car => car.Category).Include(car => car.Sticker).ToList<Car>();
                
                return View("Index", carsList);
            }
        }

        //controller pagina dei dettagli
        public IActionResult Details(int id)
        {
            using (StoreContext db = new StoreContext())
            {
                Car carSelected = db.Cars
                    .Where(singolaCar => singolaCar.Id == id)
                    .Include(car => car.Category)
                    .Include(car => car.Sticker)
                    .FirstOrDefault();

                if(carSelected != null)
                {
                    return View(carSelected);
                }

                return NotFound("L'auto con questo id non è stata trovata");
            }
        }

        //controller modifica auto
        [HttpGet]
        public IActionResult Update(int id)
        {
            using (StoreContext db = new StoreContext())
            {
                Car carSelected = db.Cars
                   .Where(singolaCar => singolaCar.Id == id)
                   .Include(car => car.Category)
                   .Include(car => car.Sticker)
                   .FirstOrDefault();


                if (carSelected != null)
                {
                    List<Category> categoriesInDb = db.Categories.ToList();
                    List<Sticker> stickersInDb = db.Stickers.ToList();

                    CarCategory viewModel = new CarCategory();
                    viewModel.Car = carSelected;
                    viewModel.Categories = categoriesInDb;
                    viewModel.Stickers = stickersInDb;

                    return View("Update", viewModel);
                }
                else
                {
                    return NotFound("L'auto con questo id non è stata trovata");

                }

               
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id ,CarCategory carModified)
        {
            if (!ModelState.IsValid)
            {
                using (StoreContext db = new StoreContext())
                {
                    List<Category> categoriesInDb = db.Categories.ToList();
                    List<Sticker> stickersInDb = db.Stickers.ToList();

                    carModified.Categories = categoriesInDb;
                    carModified.Stickers = stickersInDb;
                }

                return View("Update", carModified);
            }

            using(StoreContext db = new StoreContext())
            {
                Car carSelected = db.Cars
                    .Where(car => car.Id == id)
                    .Include(car => car.Category)
                    .Include(car => car.Sticker)
                    .FirstOrDefault();

                if(carSelected != null)
                {
                    carSelected.Name = carModified.Car.Name;
                    carSelected.Description = carModified.Car.Description;
                    carSelected.Color = carModified.Car.Color;
                    carSelected.Price = carModified.Car.Price;
                    carSelected.Url_image = carModified.Car.Url_image;
                    carSelected.Quantity = carModified.Car.Quantity;
                    carSelected.CategoryId = carModified.Car.CategoryId;
                    carSelected.StickerId = carModified.Car.StickerId;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                { 
                    return NotFound("L'auto con questo id non è stata trovata");
                }
            }
        }

        //controller crea nuova auto
        [HttpGet]
        public IActionResult Create()
        {
            using(StoreContext db = new StoreContext())
            {
                List<Category> categoriesInDb = db.Categories.ToList<Category>();
                List<Sticker> stickersInDb = db.Stickers.ToList<Sticker>();

                CarCategory viewModel = new CarCategory();

                viewModel.Car = new Car();
                viewModel.Categories = categoriesInDb;
                viewModel.Stickers = stickersInDb;

                return View("Create", viewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarCategory newCar)
        {
            if (!ModelState.IsValid)
            {
                using (StoreContext db = new StoreContext())
                {
                    List<Category> categoriesInDb = db.Categories.ToList<Category>();
                    List<Sticker> stickersInDb = db.Stickers.ToList<Sticker>();

                    newCar.Categories = categoriesInDb;
                    newCar.Stickers = stickersInDb;
                }

                return View("Create", newCar);
            }

            using (StoreContext db = new StoreContext())
            {
                db.Cars.Add(newCar.Car);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //conferma per eliminare auto selezionata
        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            using (StoreContext db = new StoreContext())
            {
                Car carSelected = db.Cars
                   .Where(singolaCar => singolaCar.Id == id)
                   .Include(car => car.Category)
                   .Include(car => car.Sticker)
                   .FirstOrDefault();


                if (carSelected != null)
                {
                    return View(carSelected);
                }
                else
                {
                    return NotFound("L'auto con questo id non è stata trovata");

                }
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using (StoreContext db = new StoreContext())
            {
                Car carSelected = db.Cars
                    .Where(car => car.Id == id)
                    .FirstOrDefault();

                if (carSelected != null)
                {
                    db.Cars.Remove(carSelected);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("L'auto con questo id non è stata trovata");
                }

            }
        }


        public IActionResult Storage()
        {
            using (StoreContext db = new StoreContext())
            {
                List<Car> carsList = db.Cars.ToList<Car>();

                return View("Storage", carsList);
            }
        }
    }
}

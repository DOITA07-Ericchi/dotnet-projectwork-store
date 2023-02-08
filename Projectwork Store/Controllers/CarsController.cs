using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projectwork_Store.Database;
using Projectwork_Store.Models;

namespace Projectwork_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {
            using (StoreContext db = new StoreContext())
            {
                List<Car> cars = new List<Car>();

                if (search is null || search == "")
                {
                    cars = db.Cars.Include(car => car.Category).Include(car => car.Sticker).ToList<Car>();
                }
                else
                {
                    search = search.ToLower();

                    cars = db.Cars.Where(car => car.Name.ToLower().Contains(search))
                        .Include(car => car.Category)
                        .Include(car => car.Sticker).ToList<Car>();
                }

                return Ok(cars);

            }


        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            using (StoreContext db = new StoreContext())
            {
                Car cars = db.Cars.Where(car => car.Id == id).Include(car => car.Category).Include(car => car.Sticker).FirstOrDefault();

                if (cars is null)
                {
                    return NotFound("L'auto non è stata trovata!");
                }

                return Ok(cars);
            }
        }
        public IActionResult Details(int id)
        {


            using (StoreContext db = new StoreContext())

            {
                Car cars = db.Cars.Where(car => car.Id == id).Include(car => car.Category).Include(car => car.Sticker).FirstOrDefault();
                if (cars != null)
                {
                    return Ok(cars);
                }

                return NotFound("L'auto non è stata trovata!");

            }



        }

        /*
        [HttpGet("{id}")]
        public IActionResult ClientPurchase(int id)
        {
            using (StoreContext db = new StoreContext())
            {
                Car cars = db.Cars.Where(car => car.Id == id).Include(car => car.Category).Include(car => car.Sticker).FirstOrDefault();
                
                if(cars == null)
                {
                    return NotFound("Non è possibile acquistare quest'auto");
                }
                else
                {
                    UserPurchase purchase = new UserPurchase();
                    purchase.CarId = id;
                    return Ok(purchase);
                }
            }
        }

        
        [HttpPost("{id}")]
        public IActionResult ClientPurchase(int id, [FromBody] UserPurchase purchaseModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            purchaseModel.CarId = id;

            using (StoreContext db = new StoreContext())
            {
                Car carSelected = db.Cars
                    .Where(car => car.Id == id)
                    .FirstOrDefault();

                int newQuantity = carSelected.Quantity - purchaseModel.Quantity;

                db.UserPurchases.Add(purchaseModel);
                carSelected.Quantity = newQuantity;

                db.SaveChanges();

                return Ok();

            }
           
        }*/



    }
}

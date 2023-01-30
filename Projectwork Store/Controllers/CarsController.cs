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
                    cars = db.Cars.Include(car => car.Category).Include(pizza => pizza.Sticker).ToList<Car>();
                }
                else
                {
                    search = search.ToLower();

                    cars = db.Cars.Where(car => car.Name.ToLower().Contains(search))
                        .Include(car => car.Category)
                        .Include(pizza => pizza.Sticker).ToList<Car>();
                }

                return Ok(cars);

            }


        }
    }
}

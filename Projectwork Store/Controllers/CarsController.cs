﻿using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            using (StoreContext db = new StoreContext())
            {
                Car cars = db.Cars.Where(pizza => pizza.Id == id).Include(car => car.Category).Include(pizza => pizza.Sticker).FirstOrDefault();

                if (cars is null)
                {
                    return NotFound("L'auto non è stata trovata!");
                }

                return Ok(cars);
            }
        }
        public IActionResult Dettaglio(int id)
        {


            using (StoreContext db = new StoreContext())

            {
                Car cars = db.Cars.Where(pizza => pizza.Id == id).Include(car => car.Category).Include(pizza => pizza.Sticker).FirstOrDefault();
                if (cars != null)
                {
                    return Ok(cars);
                }

                return NotFound("La pizza con l'id cercato non esiste!");

            }



        }

    }
}

using TravelApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private TravelApiContext _db;

        public CitiesController(TravelApiContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult<IEnumerable<City>> Get(string name)
        {
            var query = _db.Cities.AsQueryable()
                .Include(city => city.Reviews);

            if (name != null)
            {
                query = query.Where(city => city.Name == name)
                    .Include(city => city.Reviews);
            }
            return query.ToList();
        }
        [HttpPost]
        public void Post([FromBody] City city)
        {
            _db.Cities.Add(city);
            _db.SaveChanges();
        }
        [HttpGet("{id}")]
        public ActionResult<City> Get(int id)
        {
            return _db.Cities.FirstOrDefault(entry => entry.CityId == id);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] City city)
        {
            city.CityId = id;
            _db.Entry(city).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/cities/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cityToDelete = _db.Cities.FirstOrDefault(entry => entry.CityId == id);
            _db.Cities.Remove(cityToDelete);
            _db.SaveChanges();
        }

        [HttpGet("brew")]
        public ActionResult Brew()
        {
            return StatusCode(418);
        }
    }
}
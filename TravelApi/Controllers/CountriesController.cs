using TravelApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private TravelApiContext _db;

        public CountriesController(TravelApiContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Country>> Get(string name)
        {
            var query = _db.Countries.AsQueryable();
            if (name != null)
            {
                query = query.Where(entry => entry.Name == name);
            }
            return query.ToList();
        }
        [HttpPost]
        public void Post([FromBody] Country country)
        {
            _db.Countries.Add(country);
            _db.SaveChanges();
        }
        [HttpGet("{id}")]
        public ActionResult<Country> Get(int id)
        {
            return _db.Countries.FirstOrDefault(entry => entry.CountryId == id);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Country country)
        {
            country.CountryId = id;
            _db.Entry(country).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/cities/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var countryToDelete = _db.Countries.FirstOrDefault(entry => entry.CountryId == id);
            _db.Countries.Remove(countryToDelete);
            _db.SaveChanges();
        }
    }
}
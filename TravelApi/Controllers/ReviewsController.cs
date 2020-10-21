using TravelApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private TravelApiContext _db;

        public ReviewsController(TravelApiContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get(string city, string country)
        {
            var query = _db.Reviews.AsQueryable();
            if (city != null)
            {
                query = query.Where(entry => entry.City.Name == city);   
            }

            if (country != null)
            {
                query = query.Where(entry => entry.City.Country.Name == country);
            }
            return query.ToList();
        }
        [HttpPost]
        public void Post([FromBody] Review review)
        {
            _db.Reviews.Add(review);
            _db.SaveChanges();
        }
        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            return _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Review review, string userName)
        {
            review.ReviewId = id;
            if (userName != null)
            {
                if (review.UserName == userName)
                {
                    _db.Entry(review).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("User name doesn't match");
                }
            }
            else 
            {
                Console.WriteLine("User name is required for editing");
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id, [FromBody] Review review, string userName)
        {   var reviewToDelete = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
            if (userName != null)
            {
                if (review.UserName == userName)
                {
                    _db.Reviews.Remove(reviewToDelete);
                    _db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("User name doesn't match");
                }
            }
            else 
            {
                Console.WriteLine("User name is required to delete reviews");
            }
        }
    }
}
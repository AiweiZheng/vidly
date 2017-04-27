using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.Dtos;
using vidly.Models;
using Vidly.Models;

namespace vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();    
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalsDto newRentalDto)
        {
           
            var customer = _context.Customers.Single(
                c => c.Id == newRentalDto.CustomerId);
            var movies = _context.Movies.Where(
                m => newRentalDto.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                var rental = new Rental
                {
                    Movie = movie,
                    Customer = customer,
                    DateRented = DateTime.Now
                };
                movie.NumberAvailable--;
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}

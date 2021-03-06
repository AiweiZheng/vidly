﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using vidly.Dtos;
using vidly.Models;
using Vidly.Models;

namespace vidly.Controllers.Api
{
    public class MoviesController:ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();    
        }

        //Get /api/movies 
        [HttpGet]
        public IHttpActionResult GetMovies(string query)
        {
            var movieQuery = _context.Movies
                .Include(m => m.MovieGenre)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                movieQuery = movieQuery.Where(m => m.Name.Contains(query));
            }

            var movieDtos = movieQuery
                            .ToList()
                            .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }

        // /api/movies/id
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies
                .Include(m => m.MovieGenre)
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);
        }

        // /api/movies
        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Customers.FirstOrDefault(m => m.Id == movieDto.Id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieInDb, movieInDb);
            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
    
}
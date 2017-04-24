using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;
using Vidly.Models;

namespace vidly.Controllers.ViewModels
{
    public class MovieFormViewModel
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(0, 20)]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? MovieGenreId { get; set; }

        public IEnumerable<MovieGenre> MovieGenre { get; set; }

        public string Title
        {
            get
            {
                return Id != 0? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id            = movie.Id;
            Name          = movie.Name;
            ReleaseDate   = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            MovieGenreId  = movie.MovieGenreId;
        }
    }
}
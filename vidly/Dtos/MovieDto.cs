using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Range(0, 20)]
        public int NumberInStock { get; set; }

        [Required]
        public byte MovieGenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public MovieGenreDto MovieGenre { get; set; }

        public DateTime DateAdded { get; set; }

    }
}
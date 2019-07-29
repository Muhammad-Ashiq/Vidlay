using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidlay.Models
{
    public class Movie
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        
        public DateTime DateAdded { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Range(1,20)]
        [Display(Name = "Number In Stock" )]
        [Required]
        public byte NumberInStock { get; set; }


        public Genre Genre { get; set; }    
        [Required]
        [Display(Name ="Genre")]
        public byte GenreId { get; set; }

        public byte NumberAvailable { get; set; }









    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidlay.Models;

namespace Vidlay.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 20)]
        [Required]
        public byte NumberInStock { get; set; }

        public GenraDto Genre { get; set; }



        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}
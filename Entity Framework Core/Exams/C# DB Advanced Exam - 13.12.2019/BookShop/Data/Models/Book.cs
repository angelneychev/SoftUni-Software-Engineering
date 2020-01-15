﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookShop.Data.Models.Enums;

namespace BookShop.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }

        //TODO - не е ясно дали не трябва да е null ? 
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        //TODO - не е ясно дали не трябва да е null ? 
        [Range(50, 5000)]
        public int Pages { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        public ICollection<AuthorBook> AuthorsBooks { get; set; } = new HashSet<AuthorBook>();
    }
}

//Book
//•	Id - integer, Primary Key
//•	Name - text with length[3, 30]. (required)
//•	Genre - enumeration of type Genre, with possible values(Biography = 1, Business = 2, Science = 3) (required)
//•	Price - decimal in range between 0.01 and max value of the decimal
//•	Pages – integer in range between 50 and 5000
//•	PublishedOn - date and time(required)
//•	AuthorsBooks - collection of type AuthorBook

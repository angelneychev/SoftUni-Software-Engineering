﻿using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class AuthorBook
    {
        [Required]
        public int AuthorId { get; set; }
        public Author Author { get; set; }


        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}

//AuthorBook
//•	AuthorId - integer, Primary Key, Foreign key(required)
//•	Author -  Author
//•	BookId - integer, Primary Key, Foreign key(required)
//•	Book - Book
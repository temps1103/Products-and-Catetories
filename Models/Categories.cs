using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Products_and_Categories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {get;set;}
        [Required]
        [MinLength(2, ErrorMessage ="Name must be at least 2 characters long.")]
        public string Name {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        // List of the (Products) under categories in the Market
        public List<Market> ListOfProducts {get;set;}
    }
}
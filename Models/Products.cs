using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Products_and_Categories.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get;set;}
        [Required]
        [MinLength(2, ErrorMessage ="Name must be at least 2 characters long.")]
        public string Name {get;set;}
        [Required]
        [MinLength(20, ErrorMessage ="Discription must be at least 20 characters long.")]
        public string Description {get;set;}
        [Required]
        [Range(0.01,int.MaxValue, ErrorMessage ="No Free stuff on this site! Price must be above 0.")]
        public int Price {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        // List of the products (Categories) in the market
        public List<Market> CategoriesSoldIn {get;set;}
    }
}
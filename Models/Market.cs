using System;
using System.ComponentModel.DataAnnotations;

namespace Products_and_Categories.Models
{
    public class Market
    {
        [Key]
        public int MarketId {get;set;}
        public int ProductId {get;set;}
        public int CategoryId {get;set;}

        // Then we need Navigation Properties
        public Product Product {get;set;}
        public Category Category {get;set;}
    }
}
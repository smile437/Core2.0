using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreApp.DbAccess.Models
{
    public class Product
    {
        [Key]
        public int Code { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime DeliveryDate { get; set; }


        
        public ICollection<ProductCategory> Categories { get; set; }

        public ProductType ProductType { get; set; }

        public Unit Unit { get; set; }

        public Product()
        {
            this.Categories = new List<ProductCategory>();
        }
    }
}

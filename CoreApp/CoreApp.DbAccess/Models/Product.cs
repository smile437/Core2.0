using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("ProductType")]
        public int ProductTypeCode { get; set; }

        public virtual ProductType ProductType { get; set; }

        [ForeignKey("Unit")]
        public int UnitCode { get; set; }

        public virtual Unit Unit { get; set; }

        public Product()
        {
            this.Categories = new List<ProductCategory>();
        }
    }
}

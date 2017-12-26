using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreApp.DbAccess.Models
{
    public class Category
    { 
        [Key]
        public int Code { get; set; }

        public string Description { get; set; }

        public ICollection<ProductCategory> Products { get; set; }

        public Category()
        {
            this.Products = new List<ProductCategory>();
        }
    }
}

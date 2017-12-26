using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreApp.DbAccess.Models
{
    public class ProductCategory
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey(nameof(ProductCategory.Category))]
        public int CategoryCode { get; set; }

        public Category Category { get; set; }


        [Key]
        [Column(Order = 2)]
        [ForeignKey(nameof(ProductCategory.Product))]
        public int ProductCode { get; set; }

        public Product Product { get; set; }
    }
}

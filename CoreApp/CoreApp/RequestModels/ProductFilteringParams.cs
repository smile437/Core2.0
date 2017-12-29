using CoreApp.DbAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.RequestModels
{
    public class ProductFilteringParams
    {
        public string FilterByType { get; set; }

        public string FilterByCategory { get; set; }

        public string FilterByEntity { get; set; }

        public static implicit operator ProductFilter(ProductFilteringParams p)
        {
            if (p == null)
                return null;

            return new ProductFilter(p.FilterByType, p.FilterByCategory, p.FilterByEntity);
        }
    }
}

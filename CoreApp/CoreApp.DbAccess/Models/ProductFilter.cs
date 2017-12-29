using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreApp.DbAccess.Models
{
    public class ProductFilter
    {
        public readonly IEnumerable<string> FilterByType;

        public readonly IEnumerable<string> FilterByCategory;

        public readonly IEnumerable<string> FilterByEntity;

        public ProductFilter(string types, string categories, string entities)
        {
            this.FilterByType = SplitByComma(types);
            this.FilterByCategory = SplitByComma(categories);
            this.FilterByEntity = SplitByComma(entities);
        }

        private static IEnumerable<string> SplitByComma(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return Enumerable.Empty<string>();

            return str.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim());
        }
    }
}

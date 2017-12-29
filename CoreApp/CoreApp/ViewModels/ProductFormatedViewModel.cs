using CoreApp.Currency;
using CoreApp.DbAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.ViewModels
{
    public class ProductFormatedViewModel
    {
        public readonly string ProductDescription;
        public readonly string Price;
        public readonly string IsAvailable;
        public readonly string DeliveryDate;
        public readonly int CategoriesCount;
        public readonly string Type;
        public readonly string Unit;

        public ProductFormatedViewModel(Product product, ICurrencyExchangeStrategy currencyExchangeStrategy)
        {
            this.ProductDescription = $"({product.Code}) {product.Description}";
            // TODO: change double to decimal in db and everywhere; currencies/prices 
            // should be decimal.
            var requestedPrice = currencyExchangeStrategy.Parse(Convert.ToDecimal(product.Price));
            this.Price = $"{requestedPrice.Value.ToString("C", requestedPrice.FormatProvider)} {requestedPrice.CurrencySign}";
            this.IsAvailable = product.IsAvailable ? "Available" : "Unavailable";
            this.DeliveryDate = product.DeliveryDate.ToShortDateString();
            this.CategoriesCount = product.Categories.Count;
            this.Type = $"({product.ProductType.Code}) {product.ProductType.Description}";
            this.Unit = $"({product.Unit.Code}) {product.Unit.Description}";
        }
    }
}

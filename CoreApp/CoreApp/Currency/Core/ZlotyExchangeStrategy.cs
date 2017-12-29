using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Currency.Core
{
    public class ZlotyExchangeStrategy : ICurrencyExchangeStrategy
    {
        public const string Sign = "zł";

        public static readonly IFormatProvider FormatProvider = CultureInfo.GetCultureInfo("pl-PL");

        public CurrencyExchangeResult Parse(decimal commonCurrencyValue)
        {
            // By default, we have zloty as currency in db.
            // TODO: all other implementations should consider current exchange rate 
            // being retrieved from thrid-party API, and stored in db to make 
            // exchange operations consistent and up to date.
            return new CurrencyExchangeResult(commonCurrencyValue, Sign, FormatProvider);
        }

        public CurrencyExchangeResult Parse(decimal value, string currencySign)
        {
            if (currencySign.Equals(Sign, StringComparison.InvariantCultureIgnoreCase))
                return new CurrencyExchangeResult(value, Sign, FormatProvider);

            // TODO: This should convert from currency specified by currencySign 
            // to zloty.
            // TODO: reconsider string sign.
            throw new NotImplementedException();
        }
    }
}

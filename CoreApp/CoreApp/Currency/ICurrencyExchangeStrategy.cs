using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Currency
{
    public interface ICurrencyExchangeStrategy
    {
        CurrencyExchangeResult Parse(decimal commonCurrencyValue);

        CurrencyExchangeResult Parse(decimal value, string currencySign);
    }
}

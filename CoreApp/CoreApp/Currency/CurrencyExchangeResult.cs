using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Currency
{
    public class CurrencyExchangeResult
    {
        public readonly decimal Value;

        public readonly string CurrencySign;

        public readonly IFormatProvider FormatProvider;

        public CurrencyExchangeResult(decimal value, string sign, IFormatProvider formatProvider)
        {
            this.Value = value;
            this.CurrencySign = sign;
            this.FormatProvider = formatProvider;
        }
    }
}

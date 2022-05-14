using Currency.DataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Currency.DataAPI.CurrencyService
{
    interface ICurrencyService
    {
        public interface ICurrencyService
        {
            Task<CurrencyModel[]> GetToday();
            Task<CurrencyModel[]> GetByDate(DateTime date);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Currency : BaseEntity
    {
        public int Unit { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string CrossRateUsd { get; set; }
        public decimal ForexBuying { get; set; }
        public string ForexSelling { get; set; }
        public string BanknoteBuying { get; set; }
        public string BanknoteSelling { get; set; }
    }
}

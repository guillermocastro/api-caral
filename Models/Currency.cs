using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caral.Models
{
    public class Currency
    {
        public string CurrencyId { get; set; }
        public string Currency3N { get; set; }
        public int Decimal { get; set; }
        public string CurrencyName { get; set; }
        public string CurFormat { get; set; }
        public string LastValue { get; set; }
        public string TimeStamp { get; set; }
        public bool IsDisabled { get; set; }
    }
}
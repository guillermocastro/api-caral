using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caral.Models
{
    public class Balance
    {
        public string BalanceId { get; set; }
        public string BalanceName { get; set; }
        public string ParentId { get; set; }
        public string AccountList { get; set; }
    }
}
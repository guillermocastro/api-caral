using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caral.Models
{
    public class Account
    {
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string Description { get; set; }
        public string BalanceId { get; set; }
        public string StatementId { get; set; }
        public Nullable<bool> IsDisabled { get; set; }
    }
}
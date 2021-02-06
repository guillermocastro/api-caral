using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caral.Models
{
    public class PaymenMethod
    {
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
        public string AccountId { get; set; }
        public Nullable<bool> IsDisabled {get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caral.Models
{
    public class Term
    {
        public int TermId { get; set; }
        public string TermName { get; set; }
        public int Days { get; set; }
        public string PaymentDays { get; set; }
        public Nullable<bool> IsDisabled { get; set; }
    }
}
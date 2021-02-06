using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caral.Models
{
    public class Statement
    {
        public string StatementId { get; set; }
        public string StatementName { get; set; }
        public string ParentId { get; set; }
        public string AccountList { get; set; }
    }
}
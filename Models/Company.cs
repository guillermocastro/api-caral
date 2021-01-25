using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caral.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNo { get; set; }
        public string Tradename { get; set; }
        public string TermId { get; set; }
        public string CountryId { get; set; }
        public string CurrencyId { get; set; }
        public string ContactName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string PostCode { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Telefone3 { get; set; }
        public string EMail { get; set; }
        public string Url { get; set; }
        public string LegalConditions { get; set; }
        public string Members { get; set; }
    }
}
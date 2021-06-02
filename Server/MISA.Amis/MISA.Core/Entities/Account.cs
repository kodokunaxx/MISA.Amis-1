using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class Account : BaseEntity
    {
        public Guid AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string EnglishName { get; set; }
        public string Kind { get; set; }
        public string Explain { get; set; }
        public int IsKeepBusinessAccount { get; set; }
        public string Target { get; set; }
        public string TargetTHCP { get; set; }
        public string Order { get; set; }
        public string PurchaseContract { get; set; }
        public string Unit { get; set; }
        public int BankAccount { get; set; }
        public string Construction { get; set; }
        public string SellContract { get; set; }
        public string Items { get; set; }
        public string StatisticalCode { get; set; }
        public int lft { get; set; }
        public int rgt { get; set; }
    }
}

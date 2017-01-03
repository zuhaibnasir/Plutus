using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plutus.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public string Name  { get; set; }
        public string BankName  { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal AvailableCredit { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid  { get; set; }
        public decimal APR { get; set; }
        public decimal ExpectedInterest  { get; set; }
}
}

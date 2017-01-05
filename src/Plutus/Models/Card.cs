using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plutus.Models {
    public class Card {
        public int ID { get; set; }

        [Display(Name ="Bank Name")]
        public string BankName { get; set; }

        [Display(Name = "Card Name")]
        public string CardName { get; set; }
        public int DueDay { get; set; }

        [Display(Name = "Credit Limit")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal CreditLimit { get; set; }

        [Display(Name = "Annual Percentage Rate")]
        public decimal APR { get; set; }        

        public ICollection<Website> UsedBy { get; set; }

        public int WebsiteID { get; set; }        
        public Website Website { get; set; }

        public ICollection<MonthlyData> MonthlyRecords { get; set; }

    }
}

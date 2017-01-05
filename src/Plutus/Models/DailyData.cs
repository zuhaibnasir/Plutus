using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plutus.Models {
    public class DailyData {

        public int ID { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Available Credit")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal AvailableCredit { get; set; }

        public int MonthlyDataID { get; set; }

        public MonthlyData MonthlyData { get; set; }
    }
}

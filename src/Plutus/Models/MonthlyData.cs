using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Plutus.Models {
    public class MonthlyData {
        public int ID { get; set; }
        public int Month { get; set; }

        [Display(Name ="Is Paid")]
        public Boolean IsPaid { get; set; }
        public ICollection<DailyData> DailyRecords { get; set; }

        public int CardID { get; set; }
        public Card Card { get; set; }
    }
}

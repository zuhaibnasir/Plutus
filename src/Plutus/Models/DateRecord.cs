using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plutus.Models
{
    public class DateRecord {
        public string Date { get; set; }

        public List<BalanceRecord> BalanceRecords {get;set;}

        public static List<DateRecord> GetDailyRecords(List<DailyData> currentMonthData) {
            List<DateRecord> records = new List<Models.DateRecord>();

            var dates = currentMonthData.Select(d => d.Date.Date).Distinct().ToList();
            foreach (DateTime date in dates) {
                var dailyRecords = currentMonthData.Where(d => d.Date.Date.Equals(date.Date));
                List<BalanceRecord> balanceRecords = new List<BalanceRecord>();
                foreach (DailyData daily in dailyRecords) {
                    balanceRecords.Add(new BalanceRecord(daily));
                }
                records.Add(new DateRecord() { Date = date.ToString("MMMM dd yyyy"), BalanceRecords = balanceRecords });
            }

            return records;
        }

    }

    public class BalanceRecord {

        private DailyData _dailyRecord;
        public DateTime Date { get { return _dailyRecord.Date; } }
        public string CardName { get { return _dailyRecord.MonthlyData.Card.CardName; } }
        public string BankName { get { return _dailyRecord.MonthlyData.Card.BankName; } }
        public decimal TotalCredit { get { return _dailyRecord.MonthlyData.Card.CreditLimit; } }
        public decimal BalanceToday { get { return TotalCredit - _dailyRecord.AvailableCredit; } }

        public string DaysToDueDate { get {
                int days = _dailyRecord.MonthlyData.Card.DueDay - Date.Day;
                string dueDate = new DateTime(DateTime.Now.Year, _dailyRecord.MonthlyData.Month, _dailyRecord.MonthlyData.Card.DueDay).ToString("MMMM dd yyyy");
                return days > 0 ? String.Format("<span title='Due Date: {0}'>{1} days remaining</span>", dueDate, days) : String.Format("<span title='{0}' style='color:red'>Past Due</span>", dueDate);
            } }

        public BalanceRecord(DailyData dailyRecord) {
            _dailyRecord = dailyRecord;
        }
    }
}

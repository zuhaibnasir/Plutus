using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plutus.Models;

namespace Plutus.Data {
    public class DatabaseInitializer {
        public static void Initialize(PlutusContext context) {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Cards.Any()) {
                return;   // DB has been seeded
            }

            var websites = new Website[]
            {
                new Website {Name="Chase",Description="Chase website", UserName="zuhaib1980", Password="ppppp", URL="http://www.chase.com",Type=WebsiteTypes.Card  },
                new Website {Name="Discover",Description="Discover website", UserName="zuhaib.nasir", Password="ppppp", URL="http://www.discover.com",Type=WebsiteTypes.Card },
                new Website {Name="Comcast",Description="Comcast consumer", UserName="zuhaib.nasir", Password="ppppp", URL="http://www.comcast.net",Type=WebsiteTypes.Consumer},
                new Website {Name="ATT",Description="ATT consumer", UserName="zuhaib.nasir", Password="ppppp", URL="http://www.att.net",Type=WebsiteTypes.Consumer },
                new Website {Name="Netflix",Description="Netflix consumer", UserName="zuhaib.nasir@gmail.com", Password="ppppp", URL="http://www.netflix.com",Type=WebsiteTypes.Consumer }
            };
            foreach (Website w in websites) {
                context.Websites.Add(w);
            }
            context.SaveChanges();

            var cards = new Card[]
            {
                new Card{BankName="Chase", CardName="Freedom", CreditLimit=7500.00m, DueDay= 16, WebsiteID=1, APR=19.9m },
                new Card{BankName="Chase", CardName="Slate", CreditLimit=6600.00m, DueDay= 26, WebsiteID=1, APR=19.9m }
            };
            foreach (Card c in cards) {
                context.Cards.Add(c);
            }
            context.SaveChanges();
                        
            context.MonthlyRecords.Add(new MonthlyData { CardID = 1, IsPaid = false, Month = 1 });
            context.MonthlyRecords.Add(new MonthlyData { CardID = 2, IsPaid = false, Month = 1 });
            context.SaveChanges();

            var dailyRecords = new DailyData[] {
                new DailyData { AvailableCredit=2200, MonthlyDataID=1, Date=new DateTime(2017,1,4)},
                new DailyData { AvailableCredit=2200, MonthlyDataID=1, Date=new DateTime(2017,1,5)},
                new DailyData { AvailableCredit=1100, MonthlyDataID=2, Date=new DateTime(2017,1,4)},
                new DailyData { AvailableCredit=1100, MonthlyDataID=2, Date=new DateTime(2017,1,5)},
            };
            foreach (DailyData d in dailyRecords) {
                context.DailyRecords.Add(d);
            }
            context.SaveChanges();

            websites.SingleOrDefault(w => w.Name == "Comcast").CardID = 1;
            websites.SingleOrDefault(w => w.Name == "ATT").CardID = 2;
            context.SaveChanges();
        }
    }
}

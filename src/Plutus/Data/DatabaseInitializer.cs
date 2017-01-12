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
                new Website {Name="Citi",Description="Citi website", UserName="zuhaib.nasir", Password="ppppp", URL="http://www.citibank.com",Type=WebsiteTypes.Card },
                new Website {Name="CapitalOne",Description="Capital One website", UserName="zuhaib.nasir", Password="ppppp", URL="http://www.capitalOne.com",Type=WebsiteTypes.Card },
                new Website {Name="BoA",Description="Bank Of America", UserName="zuhaib.nasir", Password="ppppp", URL="https://www.bankofamerica.com/",Type=WebsiteTypes.Card },
                new Website {Name="Amex",Description="American Express", UserName="zuhaib.nasir", Password="ppppp", URL="https://www.americanexpress.com/",Type=WebsiteTypes.Card },
                new Website {Name="Barclays",Description="Barclays", UserName="zuhaib.nasir", Password="ppppp", URL="https://home.barclaycardus.com/",Type=WebsiteTypes.Card },
                new Website {Name="Amazon",Description="Amazon Store Card", UserName="zuhaib.nasir", Password="ppppp", URL="https://amazon.com/storecard",Type=WebsiteTypes.Card },
                new Website {Name="CreditOne",Description="CreditOne", UserName="zuhaib.nasir", Password="ppppp", URL="https://www.creditonebank.com/",Type=WebsiteTypes.Card },
                new Website {Name="ToysRUs(Synchrony)",Description="Toys r us Master Card", UserName="zuhaib.nasir", Password="ppppp", URL="http://toysrus.com/creditcard",Type=WebsiteTypes.Card },
                new Website {Name="Care(Synchrony)",Description="Care Credit", UserName="zuhaib.nasir", Password="ppppp", URL="https://www.carecredit.com/",Type=WebsiteTypes.Card },
                new Website {Name="Target",Description="Target Red Card", UserName="zuhaib.nasir", Password="ppppp", URL="https://rcam.target.com/",Type=WebsiteTypes.Card },
                new Website {Name="HomeDepot(Citi)",Description="Target Red Card", UserName="zuhaib.nasir", Password="ppppp", URL="http://www.homedepot.com/c/Credit_Center",Type=WebsiteTypes.Card },
                new Website {Name="JCPenny(Synchrony)",Description="JC Penny Card", UserName="zuhaib.nasir", Password="ppppp", URL="https://www.onlinecreditcenter6.com/JCPenney/occ-pay.html",Type=WebsiteTypes.Card },
                new Website {Name="Wallmart(Synchrony)",Description="Wallmart Card", UserName="zuhaib.nasir", Password="ppppp", URL="https://www2.onlinecreditcenter6.com/consumergen2/login.do?accountType=generic&clientId=walmart&subActionId=1000",Type=WebsiteTypes.Card },
                new Website {Name="WellsFargo",Description="HomeFurnishing", UserName="zuhaib.nasir", Password="ppppp", URL="https://www.wellsfargo.com/",Type=WebsiteTypes.Card },                
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
                new Card{BankName="Chase", CardName="Freedom", CreditLimit=7500.00m, DueDay= 4, WebsiteID=1, APR=23.49m },
                new Card{BankName="Chase", CardName="Slate", CreditLimit=6700.00m, DueDay= 26, WebsiteID=1, APR=22.49m },
                new Card{BankName="Discover", CardName="Discover", CreditLimit=2800.00m, DueDay= 13, WebsiteID=2, APR=20.24m },
                new Card{BankName="Citi", CardName="Forward", CreditLimit=5500.00m, DueDay= 07, WebsiteID=3, APR=11.49m },
                new Card{BankName="Citi", CardName="Diamond", CreditLimit=3000.00m, DueDay= 16, WebsiteID=3, APR=20.49m },
                new Card{BankName="Citi", CardName="CashBack", CreditLimit=4600.00m, DueDay= 14, WebsiteID=3, APR=23.24m },
                new Card{BankName="Citi", CardName="Simplicity", CreditLimit=4500.00m, DueDay= 13, WebsiteID=3, APR=0m },
                new Card{BankName="Citi", CardName="Diamond (M)", CreditLimit=7600.00m, DueDay= 22, WebsiteID=3, APR=21.49m },
                new Card{BankName="CapitalOne", CardName="QuickSilver", CreditLimit=3500.00m, DueDay= 2, WebsiteID=4, APR=18.30m },
                new Card{BankName="CapitalOne", CardName="Playstation", CreditLimit=10000.00m, DueDay= 14, WebsiteID=4, APR=17.15m },
                new Card{BankName="CapitalOne", CardName="Platinum", CreditLimit=5300.00m, DueDay= 10, WebsiteID=4, APR=0m },                
                new Card{BankName="BoA", CardName="BOA", CreditLimit=5000.00m, DueDay=18 , WebsiteID=5, APR=22.24m },
                new Card{BankName="Amex", CardName="EveryDay", CreditLimit=2000.00m, DueDay=3 , WebsiteID=6, APR=13.49m },
                new Card{BankName="Amex", CardName="BlueCash", CreditLimit=7500.00m, DueDay=16 , WebsiteID=6, APR=22.49m },
                new Card{BankName="Barclays", CardName="ArrivalPlus", CreditLimit=15400.00m, DueDay=7 , WebsiteID=7, APR=19.49m },
                new Card{BankName="Amazon", CardName="StoreCard", CreditLimit=7500.00m, DueDay=5 , WebsiteID=8, APR=0m },
                new Card{BankName="CreditOne", CardName="Platinum (M)", CreditLimit=1100.00m, DueDay=27 , WebsiteID=9, APR=24.24m },
                new Card{BankName="Synchrony", CardName="ToysRUs", CreditLimit=1500.00m, DueDay=26 , WebsiteID=10, APR=26.99m },
                new Card{BankName="Synchrony", CardName="CareCredit", CreditLimit=5000.00m, DueDay=10 , WebsiteID=11, APR=0m },
                new Card{BankName="Target", CardName="RedCard", CreditLimit=3600.00m, DueDay=2 , WebsiteID=12, APR=23.15m },
                new Card{BankName="Citi", CardName="HomeDepot", CreditLimit=4500.00m, DueDay=9 , WebsiteID=13, APR=0m },
                new Card{BankName="Synchrony", CardName="JCPenny", CreditLimit=1600.00m, DueDay=8 , WebsiteID=14, APR=24.29m },
                new Card{BankName="Synchrony", CardName="Walmart", CreditLimit=1400.00m, DueDay=3 , WebsiteID=15, APR=23.15m },
                new Card{BankName="WellsFargo", CardName="HomeFurnishing", CreditLimit=5700.00m, DueDay=7 , WebsiteID=16, APR=0m },
            };
            foreach (Card c in cards) {
                context.Cards.Add(c);
            }
            context.SaveChanges();

            int currentMonth = DateTime.Now.Month;
            foreach (Card c in context.Cards) {
                context.MonthlyRecords.Add(new MonthlyData { CardID = c.ID, IsPaid = false, Month = currentMonth });
            }          
            context.SaveChanges();

            foreach (MonthlyData monthly in context.MonthlyRecords.Where(m=>m.Month == currentMonth)) {
                context.DailyRecords.Add(new DailyData { AvailableCredit = 100, MonthlyDataID = monthly.ID, Date = DateTime.Now });
            }           
            context.SaveChanges();

            websites.SingleOrDefault(w => w.Name == "Comcast").CardID = 1;
            websites.SingleOrDefault(w => w.Name == "ATT").CardID = 2;
            context.SaveChanges();
        }
    }
}

using System;
using Xunit;
using valutebank;
using valutebank.DOMAIN;

namespace TestProject1
{
    public class Transfertest
    {

        [Fact]
        public void negativenumber()
        {
            User u = new User("testuser");
            Valute valute = new Valute("testval", "t1", "100");
            Valute valute1 = new Valute("testval2", "t2", "100");
            MainController.CreateNewBalance(u, valute);
            
            MainController.CreateNewBalance(u, valute1);

            MainController.AddToBalance(u.BalanceList[0], 100);
            MainController.AddToBalance(u.BalanceList[1], 100);

            Assert.Equal(-1, Transfer(u.BalanceList[0], u.BalanceList[1], "-100"));
        }

        [Fact]
        private void enoughtotransfer()
        {
            User u = new User("testuser");
            Valute valute = new Valute("testval", "t1", "100");
            Valute valute1 = new Valute("testval2", "t2", "100");
            MainController.CreateNewBalance(u, valute);
            MainController.CreateNewBalance(u, valute1);
            Assert.Equal(-1, Transfer(u.BalanceList[0], u.BalanceList[1], "100"));

        }

        [Fact]
        private void correctnumtotransfer()
        {
            User u = new User("testuser");
            Valute valute = new Valute("testval", "t1", "100");
            Valute valute1 = new Valute("testval2", "t2", "100");
            MainController.CreateNewBalance(u, valute);
            MainController.CreateNewBalance(u, valute1);
            MainController.AddToBalance(u.BalanceList[0], 100);
            MainController.AddToBalance(u.BalanceList[1], 100);
            Assert.Equal(-1, Transfer(u.BalanceList[0], u.BalanceList[1], "asd"));

        }

        [Theory]
        [InlineData(100)]
        private void baseTransfertest(double value)
        {
            User u = new User("testuser");
            Valute valute = new Valute("testval", "t1", "100");
            Valute valute1 = new Valute("testval2", "t2", "100");
            MainController.CreateNewBalance(u, valute);
            MainController.CreateNewBalance(u, valute1);
            MainController.AddToBalance(u.BalanceList[0], value);
            MainController.AddToBalance(u.BalanceList[1], value);
            Transfer(u.BalanceList[0], u.BalanceList[1], Convert.ToString(value));
            Assert.Equal(value*2, u.BalanceList[1].amount);
            Assert.Equal(value - value, u.BalanceList[0].amount);

        }



        public static double Transfer(Balance from, Balance to, String textAmount)
        {
            try
            {
               
                double amount = double.Parse(textAmount);
                if (amount < 0)
                {
                    return -1;
                }
                if (from.amount < amount)
                {
                    return -1;
                }
                double received = Calculate(from.valute, to.valute, textAmount);
                to.amount += received;
                from.amount -= amount;
                return amount;
            }
            catch
            {
                return -1;
            }
        }

        public static double Calculate(Valute from, Valute to, string amountStr)
        {

            double amount;
            if (double.TryParse(amountStr, out amount))
                return (from.Rate * amount) / to.Rate;
            else
                return double.NaN;
        }


    }
}

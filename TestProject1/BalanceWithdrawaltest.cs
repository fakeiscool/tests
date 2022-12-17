using System;
using Xunit;
using valutebank;
using valutebank.DOMAIN;
using System.Windows.Forms;

namespace TestProject1
{
    public class BalanceWithdrawaltest
    {

        [Fact]

        public void negativebalance()
        {
            User u = new User("testuser");
            Valute valute = new Valute("testval", "t1", "100");
            MainController.CreateNewBalance(u, valute);
            MainController.AddToBalance(u.BalanceList[0], 100);
            Assert.False(BalanceWithdrawal(u.BalanceList[0], 1000));
        }

        [Theory]
        [InlineData(100)]

        public void baseBalanceWithdrawaltest(double value)
        {
            User u = new User("testuser");
            Valute valute = new Valute("testval", "t1", "100");
            MainController.CreateNewBalance(u, valute);
            MainController.AddToBalance(u.BalanceList[0], value*2);
            BalanceWithdrawal(u.BalanceList[0], value);
            double checknum = u.BalanceList[0].amount;
            Assert.Equal(value, checknum);
        }


        public static bool BalanceWithdrawal(Balance balance, double amount)
        {
            try
            {
                if (balance.amount < amount)
                {
                    return false;
                }
                balance.amount -= amount;
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}

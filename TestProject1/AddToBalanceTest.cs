using System;
using Xunit;
using valutebank;
using valutebank.DOMAIN;

namespace TestProject1
{
    public class AddToBalanceTest
    {
        [Fact]
        public void negativenumber()
        {
            User u = new User("testuser");
            Valute valute = new Valute("testval", "t1", "100");
            MainController.CreateNewBalance(u, valute);
            MainController.AddToBalance(u.BalanceList[0], -100);
            double checknum = u.BalanceList[0].amount;
            Assert.Equal(0, checknum);

        }

        [Theory]
        [InlineData(100)]
        public void basetestaddbalance(double value)
        {
            User u = new User("testuser");
            Valute valute = new Valute("testval", "t1", "100");
            MainController.CreateNewBalance(u, valute);
            MainController.AddToBalance(u.BalanceList[0], value);
            double checknum = u.BalanceList[0].amount;
            Assert.Equal(value, checknum);

        }


    }
}

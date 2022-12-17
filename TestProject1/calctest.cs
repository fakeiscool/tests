using System;
using Xunit;
using valutebank;
using valutebank.DOMAIN;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TestProject1
{
    public class calctest
    {

        [Fact]
        public void notnumber()
        {
            Valute valute1 = new Valute("testval", "t1", "1000");
            MainController.AddValute(valute1);
            Valute valute2 = new Valute("testval2", "t2", "1000");
            MainController.AddValute(valute2);
            Assert.Equal(double.NaN,Calculate(valute1, valute2, "asd"));
        }

        [Fact]
        public void smallnumber()
        {
            Valute valute1 = new Valute("testval", "t1", "0,00000001");
            MainController.AddValute(valute1);
            Valute valute2 = new Valute("testval2", "t2", "10000000000");
            MainController.AddValute(valute2);
            double amount = Calculate(valute1, valute2, "10000000");
            Assert.NotEqual(0, amount);
        }

        [Fact]
        public void bignumber()
        {
            Valute valute1 = new Valute("testval", "t1", "10000000000");
            MainController.AddValute(valute1);
            Valute valute2 = new Valute("testval2", "t2", "0,00000001");
            MainController.AddValute(valute2);
            double checknumber = (10000000000 / 0.00000001) * 100000;
            Assert.Equal(checknumber, Calculate(valute1, valute2, "100000"));
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

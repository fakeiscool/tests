using System;
using Xunit;
using valutebank.MainController;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(4, Calculate(2, 2));
        }
    }
}

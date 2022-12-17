using System;
using Xunit;
using valutebank;
using valutebank.DOMAIN;

namespace TestProject1
{
    public class UserTests
    {

        [Theory]
        [InlineData("egor")]
        [InlineData("!@#$%%^&*()?>/''][./.,")]
        public void ForbiddenSymbolsUserTest(string value)
        {
            User u = new User(value);
            Assert.False(MainController.AddUser(u));

        }

        [Fact]
        public void SameUserTest()
        {
            string value = "EGOR";
            User u = new User(value);
            Assert.True(MainController.AddUser(u));
            Assert.False(MainController.AddUser(u));
        }


    }
}

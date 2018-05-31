using System;
using Xunit;
using UnitTestLab1;


namespace TestForLab1
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldIncrementBalance()
        {
            Account Account = new Account(100/*, 0.13*/);

            double deposit = 100;
            Account.Deposit(deposit);
            double actualBalance = Account.Balance;
            double expectedBalance = 200;
            Assert.Equal(expectedBalance, actualBalance);
        }
    }
}

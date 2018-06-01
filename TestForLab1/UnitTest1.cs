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

            double amount = 100;
            Account.Deposit(amount);
            double actualBalance = Account.Balance;
            double expectedBalance = 200;
            Assert.Equal(expectedBalance, actualBalance);
        }

        [Fact]
        public void ShouldThrowExceptionIfOverlimit()
        {
            Account Account = new Account(100/*, 0.13*/);

            double amount = 500001;

            Assert.Throws<Exception>(() => {

                Account.Deposit(amount);
            });
        }


        [Fact]
        public void ShouldThrowExceptionIfUnderlimit()
        {
            Account Account = new Account(100/*, 0.13*/);

            double amount = -1;

            Assert.Throws<Exception>(() => {

                Account.Deposit(amount);
            });
        }
        [Fact]
        public void ShouldWithdrawAmountIfValid()
        {
            Account Account = new Account(100/*, 0.13*/);

            double amount = 50;
            Account.Withdraw(amount);
            double actualBalance = Account.Balance;
            double expectedBalance = 50;
            Assert.Equal(expectedBalance, actualBalance);

        }
        [Fact]
        public void ShouldThrowExceptionIfBroke()
        {
            Account Account = new Account(0/*, 0.13*/);

            double amount = 100;

            Assert.Throws<Exception>(() => {

                Account.Withdraw(amount);
            });

        }
        [Fact]
        public void ShouldThrowExceptionIfWithdrawIsOverLimit()
        {
            Account Account = new Account(50000/*, 0.13*/);
            double amount = 10000;

            Assert.Throws<Exception>(() => {

                Account.Withdraw(amount);
            });
        }
        [Fact]
        public void ShouldThrowExceptionIfAmountMinus()
        {
            Account Account = new Account(100/*, 0.13*/);

            double amount = -1;

            Assert.Throws<Exception>(() => {

                Account.Withdraw(amount);
            });
        }
        [Fact]
        public void ShouldTransferToSavingsIfSuccessfull()
        {
            Account Account = new Account(1000/*, 0.13*/);
            Account SavingAccount = new Account(250/*, 0.13*/);

            double amount = 500;
            Account.Transfer(SavingAccount,amount);
            double actualBalance = SavingAccount.Balance;
            double expectedBalance = 750;
            Assert.Equal(expectedBalance, actualBalance);

        }
        [Fact]
        public void ShouldWithdrawFromAccount()
        {
            Account Account = new Account(1000/*, 0.13*/);
            Account SavingAccount = new Account(250/*, 0.13*/);
            double amount = 500;

            Account.Transfer(SavingAccount, amount);
            double actualBalance = Account.Balance;
            double expectedBalance = 500;
            Assert.Equal(expectedBalance, actualBalance);
        }
    }
}

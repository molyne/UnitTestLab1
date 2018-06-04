using System;
using Xunit;
using UnitTestLab1;


namespace TestForLab1
{
    public class UnitTest1
    {

        [Fact]
        public void ShouldIncrementBalanceOnDeposit()
        {
            Account Account = new Account(100, 0.02);

            double amount = 100;
            Account.Deposit(amount);
            double actualBalance = Account.Balance;
            double expectedBalance = 200;
            Assert.Equal(expectedBalance, actualBalance);
        }

        [Theory]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NaN)]
        public void ShouldThrowExceptionIfAmountNotValidOnDeposit(double amount)
        {
            Account Account = new Account(100, 0.02);


            Assert.Throws<Exception>(() =>
            {

                Account.Deposit(amount);
            });
        }

        [Fact]
        public void ShouldWithdrawAmountIfValid()
        {
            Account Account = new Account(100, 0.02);

            double amount = 50;
            Account.Withdraw(amount);
            double actualBalance = Account.Balance;
            double expectedBalance = 50;
            Assert.Equal(expectedBalance, actualBalance);

        }

        [Fact]
        public void ShouldThrowExceptionIfBrokeOnWithdraw()
        {
            Account Account = new Account(0, 0.02);

            double amount = 100;

            Assert.Throws<Exception>(() =>
            {

                Account.Withdraw(amount);
            });

        }

        [Theory]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NaN)]
        public void WithdrawShouldThrowExceptionIfNotValidAmount(double amount)
        {
            Account Account = new Account(100, 0.02);


            Assert.Throws<Exception>(() =>
            {

                Account.Withdraw(amount);
            });
        }
        [Fact]
        public void ShouldTransferToSavingsIfSuccessfull()
        {
            Account Account = new Account(1000, 0.02);
            Account SavingAccount = new Account(250, 0.02);

            double amount = 500;
            Account.Transfer(SavingAccount, amount);
            double actualBalance = SavingAccount.Balance;
            double expectedBalance = 750;
            Assert.Equal(expectedBalance, actualBalance);

        }
        [Fact]
        public void ShouldWithdrawFromAccountOnTransfer()
        {
            Account Account = new Account(1000, 0.02);
            Account SavingAccount = new Account(250, 0.02);
            double amount = 500;

            Account.Transfer(SavingAccount, amount);
            double actualBalance = Account.Balance;
            double expectedBalance = 500;
            Assert.Equal(expectedBalance, actualBalance);
        }

        [Theory]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NaN)]
        public void ShouldThrowAnExceptionOnNotValidNumberWhenTransfer(double amount)
        {
            Account Account = new Account(1000, 0.02);
            Account SavingAccount = new Account(250, 0.02);

            Assert.Throws<Exception>(() =>
            {

                Account.Transfer(SavingAccount, amount);
            });

        }
        [Fact]
        public void ShouldThrowAnExceptionIfTransferToSameAccount()
        {
            Account Account = new Account(1000, 0.02);
            double amount = 500;

            Assert.Throws<Exception>(() =>
            {

                Account.Transfer(Account, amount);
            });
        }
        [Fact]
        public void TransferShouldThrowAnExceptionIfNotEnoughFunds()
        {
            Account Account = new Account(250, 0.02);
            Account SavingAccount = new Account(250, 0.02);

            double amount = 500;

            Assert.Throws<Exception>(() =>
            {

                Account.Transfer(SavingAccount, amount);
            });
        }
        [Fact]
        public void TransferFromSavingToAccount()
        {
            Account Account = new Account(250, 0.02);
            Account SavingAccount = new Account(250, 0.02);

            double amount = 200;

            SavingAccount.Transfer(Account, amount);
        }
        [Fact]
        public void ShouldCalculateInterestRate()
        {

            Account Account = new Account(250, 0.02);

            double actualRate = Account.CalculateInterest();
            double expectedRate = 5;
            Assert.Equal(expectedRate, actualRate);
        }
        [Fact]
        public void ShouldCalculateNewBalanceWithInterestRate()
        {
            Account Account = new Account(250, 0.02);
            Account.CalculateInterest();

            double actualBalance = Account.Balance;
            double expectedBalance = 255;

            Assert.Equal(expectedBalance, actualBalance);

        }
        [Theory]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NaN)]
        public void
            CalculateInterestShouldThrowAnExceptionIfBalanceIsNotValid(double balance)
        {
            Account Account = new Account(balance, 0.02);

            Assert.Throws<Exception>(() =>
            {

                Account.CalculateInterest();
            });
        }
        [Theory]
        [InlineData(double.NaN)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        public void CalculateInterestShouldThrowAnExceptionIfInterestRateIsNotValid(double interestRate)
        {

            Account Account = new Account(200, interestRate);

            Assert.Throws<Exception>(() =>
            {

                Account.CalculateInterest();
            });
        }

    }
}

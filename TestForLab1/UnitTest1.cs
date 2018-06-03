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

        [Fact]
        public void ShouldThrowExceptionIfPositiveInfinityOnDeposit()
        {
            Account Account = new Account(100, 0.02);


            Assert.Throws<Exception>(() => {

                Account.Deposit(double.PositiveInfinity);
            });
        }
        [Fact]
        public void ShouldThrowExceptionIfNegativeInfinityOnDeposit()
        {
            Account Account = new Account(100, 0.02);


            Assert.Throws<Exception>(() => {

                Account.Deposit(double.NegativeInfinity);
            });
        }
        [Fact]
        public void ShouldThrowAnExceptionOnNaNWhenDeposit()
        {
            Account Account = new Account(1000, 0.02);
           

            Assert.Throws<Exception>(() => {

                Account.Deposit(double.NaN);
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
        public void ShouldThrowAnExceptionIfNaNOnWithdraw()
        {
            Account Account = new Account(1000, 0.02);


            Assert.Throws<Exception>(() => {

                Account.Withdraw(double.NaN);
            });
        }
        [Fact]
        public void ShouldThrowExceptionIfBrokeOnWithdraw()
        {
            Account Account = new Account(0, 0.02);

            double amount = 100;

            Assert.Throws<Exception>(() => {

                Account.Withdraw(amount);
            });

        }
        [Fact]
        public void WithdrawShouldThrowExceptionIfPositiveInfinity()
        {
            Account Account = new Account(100, 0.02);


            Assert.Throws<Exception>(() => {

                Account.Withdraw(double.PositiveInfinity);
            });
        }
        [Fact]
        public void WithdrawShouldThrowExceptionIfNegativeInfinity()
        {
            Account Account = new Account(100, 0.02);


            Assert.Throws<Exception>(() => {

                Account.Withdraw(double.NegativeInfinity);
            });
        }
        [Fact]
        public void ShouldTransferToSavingsIfSuccessfull()
        {
            Account Account = new Account(1000, 0.02);
            Account SavingAccount = new Account(250, 0.02);

            double amount = 500;
            Account.Transfer(SavingAccount,amount);
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
        [Fact]
        public void ShouldThrowAnExceptionOnNaNWhenTransfer()
        {
            Account Account = new Account(1000, 0.02);
            Account SavingAccount = new Account(250, 0.02);
            

            Assert.Throws<Exception>(() => {

                Account.Transfer(SavingAccount,double.NaN);
            });
        }
        [Fact]
        public void ShouldThrowAnExceptionOnPositiveInfinityWhenTransfer()
        {
            Account Account = new Account(1000, 0.02);
            Account SavingAccount = new Account(250, 0.02);

            Assert.Throws<Exception>(() => {

                Account.Transfer(SavingAccount, double.PositiveInfinity);
            });

        }
        [Fact]
        public void ShouldThrowAnExceptionOnNegativeInfinityWhenTransfer()
        {
            Account Account = new Account(1000, 0.02);
            Account SavingAccount = new Account(250, 0.02);

            Assert.Throws<Exception>(() => {

                Account.Transfer(SavingAccount, double.NegativeInfinity);
            });

        }
        [Fact]
        public void ShouldThrowAnExceptionIfTransferToSameAccount()
        {
            Account Account = new Account(1000, 0.02);
            double amount = 500;

            Assert.Throws<Exception>(() => {

                Account.Transfer(Account, amount);
            });
        }
        [Fact]
        public void TransferShouldThrowAnExceptionIfNotEnoughFunds()
        {
            Account Account = new Account(250, 0.02);
            Account SavingAccount = new Account(250, 0.02);

            double amount = 500;

            Assert.Throws<Exception>(() => {

                Account.Transfer(SavingAccount, amount);
            });
        }
        [Fact]
        public void TransferFromSavingToAccount()
        {
            Account Account = new Account(250, 0.02);
            Account SavingAccount = new Account(250,0.02);

            double amount = 200;

            SavingAccount.Transfer(Account, amount);
        }
        [Fact]
        public void ShouldCalculateInterestRate()
        {
        
            Account Account = new Account(250,0.02);

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
        [Fact]
        public void CalculateInterestShouldThrowAnExceptionIfBalanceIsNaN()
        {
            Account Account = new Account(double.NaN, 0.02);

            Assert.Throws<Exception>(() => {

                Account.CalculateInterest();
            });
        }
        [Fact]
        public void CalculateInterestShouldThrowAnExceptionIfInterestRateIsNan()
        {

            Account Account = new Account(200, double.NaN);

            Assert.Throws<Exception>(() => {

                Account.CalculateInterest();
            });
        }
        [Fact]
        public void CalculateSholdThrowExceptionIfInfinity()
        {

            //TODO testa att skicka in flera värden med theory, alltså testa positieinfinity i samma testfall.

            Account Account = new Account(double.NegativeInfinity, 0.02);

            Assert.Throws<Exception>(() => {

                Account.CalculateInterest();
            });
        }

    }
}

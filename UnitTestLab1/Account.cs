using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestLab1
{
   public class Account
    {
        public double Balance { get; private set; }
        // TODO  public double InterestRate { get; set; }

        public Account(double initialBalance/*, double interestRate*/)
        {
            this.Balance = initialBalance;
        }

        public void Deposit(double amount)
        {

            this.Balance = this.Balance + amount;

        }
        public void Withdraw(double amount)
        {

        }
        //public bool Transfer(Account target, double amount)
        //{
        //    return;
        //}
        //public double CalculateInterest()
        //{
        //    return;
        //}

    }
}

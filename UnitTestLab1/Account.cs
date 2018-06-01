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
            if (amount <= 0)
            {
                throw new Exception("You can't deposit amount under one.");
            }
            else if (amount >= 50000)
            {
                throw new Exception("You can't deposit more than 50 000 SEK at one time. Please go to nearest bank for more information.");
            }
            else
            {
                this.Balance = this.Balance + amount;
            }
        }
        public void Withdraw(double amount)
        {
            if (this.Balance <= 0)
            {
                throw new Exception("Could not withdraw when balance under 0.");
            }
            else if (amount >= 5000)
            {
                throw new Exception("COuld not withdraw more than 5000.");
            }
            else if (amount <= 0)
            {
                throw new Exception("COuln't not withdraw negative amount.");
            }

            this.Balance = this.Balance - amount;
        }
        public bool Transfer(Account target, double amount)
        {
            if (double.IsNaN(amount))
            {
                throw new Exception("The amount is not a number");
            }
            else if (double.IsPositiveInfinity(amount) || double.IsNegativeInfinity(amount))
            {
                throw new Exception("The amount exceeded the infinity limit");
            }
            else
            {
                target.Balance = target.Balance + amount;

                this.Balance = this.Balance - amount;
            }


            return true;
        }
        //public double CalculateInterest()
        //{
        //    return;
        //}

    }
}

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
            if (double.IsPositiveInfinity(amount) || double.IsNegativeInfinity(amount))
            {
                throw new Exception("Exceeded infinity limit.");
            }
            else if (double.IsNaN(amount))
            {
                throw new Exception("Amount must be a number");
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
            else if (double.IsPositiveInfinity(amount) || double.IsNegativeInfinity(amount))
            {
                throw new Exception("Exceeded infinity limit.");
            }
            else if (double.IsNaN(amount))
            {
                throw new Exception("Amount must be anumber.");
            }

            this.Balance = this.Balance - amount;
        }
        public bool Transfer(Account target, double amount)
        {
            bool successfullTransfer = false;

            if (this == target)
            {
                throw new Exception("Can't transfer money to the same account.");
            }

            else if (double.IsNaN(amount))
            {
                throw new Exception("The amount is not a number");
            }
            else if (double.IsPositiveInfinity(amount) || double.IsNegativeInfinity(amount))
            {
                throw new Exception("The amount exceeded the infinity limit");
            }

            else
            {
                target.Deposit(amount);

                this.Withdraw(amount);

                successfullTransfer = true;

                return successfullTransfer;
            }


        }
        //public double CalculateInterest()
        //{
        //    return;
        //}

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public class BankAccount
    {
        private decimal balance;
        public decimal Balance
        {
            get => this.balance;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance can not be negative");
                }

                this.balance = value;
            }
        }

        public BankAccount(decimal balance)
        {
            this.Balance = balance;
        }

        public void Deposit(decimal sum)
        {
            if (sum <= 0 )
            {
                throw new ArgumentException("Sum must be positive number");
            }

            this.Balance += sum;
        }

        public decimal Withdraw(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Sum must be positive number");
            }
            this.Balance -= sum;
            return balance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace BankBranch

{
    class Special : Account
    {
        //bigger max balance for special and bigger daily withdraw limit
        //with 5% fees when doing a withdraw
        public double maxBalance = 10000000;
        public double minBalance = 100000;
        private double dailyWithdrawLimit = 200000;
        public Special() : base()
        {
        }
        public Special(string name, string password, double balance) : base(name, password, balance)
        {

        }

        public override bool deposit(double amount)
        {
            this.ammount = amount;
            this.balance = balance + ammount;
            Console.WriteLine("Your account balance has been deposited.\nBalance is: " + balance);
            return true;
        }
        public override bool withdraw(double amount)
        {
            this.ammount = amount;
            
            if (amount > dailyWithdrawLimit)
            {
                Console.WriteLine("Your daily withdraw limit is: 200000.");
                return false;

            }
            else if (amount > maxBalance)
            {
                Console.WriteLine("You can not withdraw that ammount of money!");
                return false;
            }
            else
            {
                if (balance == ammount)
                {
                    this.balance = balance - ammount;
                    Console.WriteLine("Your account balance has been withdrawed.\nBalance is: " + balance);
                    Console.WriteLine("All money withdrawed");
                }
                else
                {

                    balance = balance - (balance * 0.05);
                    this.balance = balance - ammount;
                    Console.WriteLine("Withdrawed!\nYour Balance after the fees is: " + balance);

                }
             
                return true;
            }
        }
    }
}


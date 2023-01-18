using System;
using System.Collections.Generic;
using System.Text;

namespace BankBranch

{
    abstract class Account
    {
        public readonly string name;
        public readonly string password;
        public readonly string ID;
        public double balance;
        protected string type;
        public double ammount;
        public abstract bool deposit(double amount);

        public abstract bool withdraw(double amount);

        public double getBalance()
        {
            return balance;
        }
        public string getAccType()
        {
            string actype;
            actype = Convert.ToString(Console.ReadLine());
            return actype;
        }
        public void printAccount()
        {

            Console.WriteLine("Name : " + name);
            Console.WriteLine("Password : " + password);
            Console.WriteLine("Balance :" + balance);
        }
        public Account()
        {

        }
        public Account(string name, string password, double balance)
        {
            this.name = name;
            this.password = password;
            this.balance = balance;
        }
    }
}


using Microsoft.VisualBasic;
using System;
using System.Reflection.Emit;

namespace BankBranch

{
    class Program
    {
        static void Main(string[] args)
        {
            String input;
            
            Bank bank = new Bank();
            Console.WriteLine("Bank Branch");
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Create account");
                Console.WriteLine("2. Show account information");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Withdraw");
                Console.WriteLine("5. Delete Account");
                Console.WriteLine("6. Clear screen");
                Console.WriteLine("7. Exit");
                object ob1 = Console.ReadLine();
                input = Convert.ToString(ob1);

                if (input == "1")
                {
                    Console.WriteLine("Enter account Type :");
                    bank.create_account();

                }
                else if (input == "2")
                {
                    Console.Write("Enter account Number :");
                    bank.showInfo();
                }
                else if (input == "3")
                {
                    Console.WriteLine("Enter Account Id: ");
                    bank.deposit();
                }
                else if (input == "4")
                {
                    Console.WriteLine("Enter Account Id: ");
                    bank.withdraw();
                }
                else if (input == "5")
                {
                    bank.deleteAcc();
                }
                else if (input == "6")
                {
                    Console.Clear();
                }
                else if (input == "7")
                {
                    Environment.Exit(0);
                }
                Console.ReadKey();


            }

        }

    }
}


using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace BankBranch
{
    class Bank
    {
        string id;
        public int idnum = 0;

        public string[] myId = new string[100];
        public string[] myName = new string[100];
        public string[] myPassword = new string[100];
        public string[] myAccType = new string[100];
        public double[] myBalance = new double[100];

        IDGenerator Id = new IDGenerator();
        Special spec = new Special();
        Normal norm = new Normal();

        //bools for loop check
        public bool checkDateL = true;
        public bool checkBalanceL = true;

        //adding account number to array
        private void GetAcc(string ID)
        {
            ID = this.id;
            myId[idnum] = ID;
            idnum++;

        }

        public void showInfo()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                Console.WriteLine("Your details: ");
                Console.WriteLine("Account Name: " + myName[indexNum]);
                Console.WriteLine("Account Password: " + myPassword[indexNum]);
                Console.WriteLine("Id: " + myId[indexNum]);
                Console.WriteLine("Account Type: " + myAccType[indexNum]);
                Console.WriteLine("Balance: " + myBalance[indexNum]);
            }
            else
            {
                Console.WriteLine("Your id is wrong!");
            }


        }
        public void deleteAcc()
        {
            int indexNum;
            Console.WriteLine("Enter your ID");
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                /* List<string> list = new List<string>(myId);
                 list.RemoveAt(list.IndexOf(inId));
                 list.Add("");
                 myId = list.ToArray();*/
                if (myAccType[indexNum] == "Normal")
                {
                    norm.withdraw(norm.balance);
                }
                else
                {
                    spec.withdraw(spec.balance);
                }
                //deleting all user information from the array
                myId = myId.Where((e, i) => i != indexNum).ToArray();
                myName = myName.Where((e, i) => i != indexNum).ToArray();
                myAccType = myAccType.Where((e, i) => i != indexNum).ToArray();
                myBalance = myBalance.Where((e, i) => i != indexNum).ToArray();
                Console.WriteLine("Account successfuly deleted");
            }
            else
            {
                Console.WriteLine("Your id is wrong!");
            }
        }

        public void create_account()
        {
            string accType;
            string name;
            string password;
            int d, m, y;
            double balance;
            string input;
            Console.WriteLine("1. Normal Account");
            Console.WriteLine("2. Special Account");
            object ob1 = Console.ReadLine();
            input = Convert.ToString(ob1);

            if (input == "1")
            {
                accType = "Normal";
                myAccType[idnum] = accType;

                //enter account name
                Console.Write("Name:");
                name = Convert.ToString(Console.ReadLine());
                myName[idnum] = name;

                //enter account password
                Console.Write("Password: ");
                password = Convert.ToString(Console.ReadLine());
                myPassword[idnum] = password;

                while (checkBalanceL == true)
                {
                    Console.WriteLine("Enter account balance: ");
                    balance = Convert.ToDouble(Console.ReadLine());
                    if (balance > norm.maxBalance)
                    {
                        Console.WriteLine("Normal Account max deposit value is: " + norm.maxBalance);
                        checkBalanceL = true;
                    }
                    else
                    {
                        myBalance[idnum] = balance;
                        checkBalanceL = false;
                    }
                }
                checkBalanceL = true;
                Console.WriteLine("Created Normal account successfully...! ");
                id = Id.generate();
                id = id + "Norm";
                Console.WriteLine("Your Account Id : " + id);
                GetAcc(id);

            }
            else if (input == "2")
            {
                accType = "Special";
                myAccType[idnum] = accType;

                //enter account name
                Console.Write("Name:");
                name = Convert.ToString(Console.ReadLine());
                myName[idnum] = name;

                //enter account password
                Console.Write("Password: ");
                password = Convert.ToString(Console.ReadLine());
                myPassword[idnum] = password;

                //balance loop
                while (checkBalanceL == true)
                {
                    Console.WriteLine("Enter account balance: ");
                    balance = Convert.ToDouble(Console.ReadLine());
                    if (balance < spec.minBalance)
                    {
                        Console.WriteLine("Special Account's min deposit value is: " + spec.minBalance);
                        checkBalanceL = true;
                    }
                    else
                    {
                        myBalance[idnum] = balance;
                        checkBalanceL = false;
                    }
                }
                checkBalanceL = true;
                Console.WriteLine("Created Special account successfully...! ");
                id = Id.generate();
                id = id + "Spec";
                Console.WriteLine("Your Account Id : " + id);
                GetAcc(id);

            }

        }

        public void deposit()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                Console.WriteLine("Your Balance is: " + myBalance[indexNum]);
                Console.WriteLine("How much you want to deposit: ");
                double depval = Convert.ToDouble(Console.ReadLine());
                if (myAccType[indexNum] == "Normal")
                {
                    norm.balance = myBalance[indexNum];
                    norm.deposit(depval);
                    myBalance[indexNum] = norm.balance;
                }
                else if (myAccType[indexNum] == "Special")
                {
                    spec.balance = myBalance[indexNum];
                    spec.deposit(depval);
                    myBalance[indexNum] = spec.balance;
                }
            }
            else
            {
                Console.WriteLine("Your id is wrong!");
            }

        }
        public void withdraw()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                Console.WriteLine("Your Balance is: " + myBalance[indexNum]);
                Console.WriteLine("How much you want to withdraw: ");
                double depval = Convert.ToDouble(Console.ReadLine());
                if (myAccType[indexNum] == "Normal")
                {
                    norm.balance = myBalance[indexNum];
                    norm.withdraw(depval);
                    myBalance[indexNum] = norm.balance;
                }
                else if (myAccType[indexNum] == "Special")
                {
                    spec.balance = myBalance[indexNum];
                    spec.withdraw(depval);
                    myBalance[indexNum] = spec.balance;
                }
            }
            else
            {
                Console.WriteLine("Your id is wrong!");
            }

        }
    }
}


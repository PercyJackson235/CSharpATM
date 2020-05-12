using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpATM
{
    class Bank
    {
        static private decimal balance = 100.00M;
        static private bool running = true;
        static readonly IDictionary validOptions = new Dictionary<string, string>
        {
            { "1","add" },{ "2","sub" },{"3","check" },{"4","quit" },{"add","add" },
            { "a","add" },{"deposit","add" },{"d","add" },{"subtract","sub" },
            { "sub","sub" },{"withdraw","sub" },{"w","sub" },{"s","sub" },{"c","check" },
            { "check","check" },{"balance","check" },{"b","check" },{"q","quit" },
            {"quit","quit" },{ "exit","quit" }
        };
        static string Menu()
        {
            string menuOption;
            Console.WriteLine("\nWould you like to :");
            Console.WriteLine("1 - add or deposit");
            Console.WriteLine("2 - subtract or withdraw");
            Console.WriteLine("3 - check balance");
            Console.WriteLine("4 - quit");
            do {
                Console.WriteLine("\nWhich option would you like?");
                menuOption = Console.ReadLine().ToLower();
            } while (!(validOptions.Contains(menuOption)));
            return (string) validOptions[menuOption];
        }
        static void CheckBalance()
        {
            Console.WriteLine("Your balance is : ${0}", balance);
        }
        static decimal GetAmount(string action)
        {
            Console.WriteLine("How much money would you like to {0}?", action);
            decimal properAmount;
            string amount = Console.ReadLine();
            try
            {
                properAmount = decimal.Parse(amount);
                if (properAmount < 0.00M)
                {
                    Console.WriteLine("Negative numbers are an invalid amount of money.");
                    return GetAmount(action);
                }
                return properAmount;
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a valid number.");
                return GetAmount(action);
            }
        }
        static void Deposit()
        {
            string action = "deposit";
            decimal amount = GetAmount(action);
            balance += amount;
            CheckBalance();
        }
        static void Withdraw()
        {
            string action = "withdraw";
            decimal amount = GetAmount(action);
            if (amount > balance)
            {
                Console.WriteLine("You do not have enought money for that action.");
                Withdraw();
            }
            balance -= amount;
            CheckBalance();
        }
        static void Main()
        {
            Console.WriteLine("Hello! Welcome to the Bank of C Sharp!");
            while (running)
            {
                switch (Menu())
                {
                    case "add":
                        Deposit();
                        break;
                    case "sub":
                        Withdraw();
                        break;
                    case "check":
                        CheckBalance();
                        break;
                    case "quit":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Not a Valid Menu Choice.");
                        break;
                }
            }
        }
    }
}

using CustomExceptions.Entities;
using CustomExceptions.Entities.Exceptions;
using Microsoft.Win32;
using System;
using System.Security.Principal;

namespace CustomExceptions // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Registry();
        }

        public static void Registry()
        {
            Account account;

            Console.Write("Enter account data\n" +
                "Number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Holder: ");
            string holder = Console.ReadLine();

            Console.Write("Inicial Balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.Write("Withdraw limit: ");
            double wLimit = double.Parse(Console.ReadLine());

            account = new Account(number, holder, balance, wLimit);

            try
            {
                Console.Write("\nEnter amount for withdraw: ");
                double whitdraw = double.Parse(Console.ReadLine());

                account.Withdraw(whitdraw);

                Console.WriteLine("Withdral made successfully!\nRemaining balance: $" + account.Balance);
            }
            catch (WhitdrawException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
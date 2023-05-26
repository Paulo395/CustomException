using CustomExceptions.Entities;
using CustomExceptions.Entities.Exceptions;
using Microsoft.Win32;
using System;
using System.Security.Principal;
using System.Xml;

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
            int number = ValidationTypeInt();

            Console.Write("Holder: ");
            string holder = ValidationString();

            Console.Write("Initial Balance: ");
            double balance = ValidationTypeDouble();

            Console.Write("Withdraw limit: ");
            double wLimit = ValidationTypeDouble();

            account = new Account(number, holder, balance, wLimit);

            try
            {
                Console.Write("\nEnter amount for withdraw: ");
                double whitdraw = ValidationTypeDouble();

                account.Withdraw(whitdraw);

                Console.WriteLine("Withdral made successfully!\nRemaining balance: $" + account.Balance);
            }
            catch (WhitdrawException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static int ValidationTypeInt()
        {
            string input;
            bool parseSucess;
            int number;

            do
            {
                input = ValidationString();
                parseSucess = int.TryParse(input, out number);

                if (parseSucess == false) Console.WriteLine("Invalid Input");

            } while (parseSucess == false);

            return number;
        }

        public static double ValidationTypeDouble()
        {
            string input;
            bool parseSucess;
            double number;

            do
            {
                input = ValidationString();
                parseSucess = double.TryParse(input, out number);

                if (parseSucess == false) Console.WriteLine("Invalid Input");

            } while (parseSucess == false);

            return number;
        }

        public static string ValidationString()
        {
            string input;

            do
            {
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) Console.WriteLine("Digite uma entrada válida");

            } while (string.IsNullOrEmpty(input));

            return input;
        }
    }
}
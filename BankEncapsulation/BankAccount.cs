using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEncapsulation
{
    public class BankAccount
    {
        private double balance = 0;
        private string Pin { get; set; }

        public void Welcome()
        {
            Console.WriteLine("Welcome to your bank!");
            do
            {
                Console.Write("To create an account, please enter a 4-character pin: ");
                Pin = Console.ReadLine();
                if (Pin.Length != 4)
                {
                    Console.WriteLine("Invalid pin. Please try again.");
                }
            } while (Pin.Length != 4);
        }

        public int MenuOptions()
        {
            Console.Clear();
            Console.WriteLine("1. Deposit\n2. Withdraw\n3. Check Balance\n4. Exit\n");
            int choice = 0;
            do
            {
                Console.Write("Enter your choice: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4);
            return choice;
        }

        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine("Money deposited.");
        }

        public double GetBalance()
        {
            return balance;
        }

        public void Withdraw(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine("Money withdrawn.");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }

        public bool ValidatePin(string pin)
        {
            return Pin == pin;
        }
    }
}

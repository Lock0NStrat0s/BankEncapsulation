using System.Diagnostics.Metrics;

namespace BankEncapsulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            bool isRunning = true;

            account.Welcome();

            while (isRunning)
            {
                switch (account.MenuOptions())
                {
                    case 1:
                        if (account.ValidatePin(GetUserInputForPin("Enter pin: ")))
                        {
                            account.Deposit(GetUserInputForFunds("Enter an amount to deposit: "));
                        }
                        else
                        {
                            Console.WriteLine("Invalid pin.");
                        }
                        break;
                    case 2:
                        if (account.ValidatePin(GetUserInputForPin("Enter pin: ")))
                        {
                            account.Withdraw(GetUserInputForFunds("Enter an amount to withdraw: "));
                        }
                        else
                        {
                            Console.WriteLine("Invalid pin.");
                        }
                        break;
                    case 3:
                        Console.WriteLine($"Balance: {account.GetBalance():C2}");
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.Write("Enter any key to continue: ");
                Console.ReadKey();
            }
        }

        public static double GetUserInputForFunds(string str)
        {
            double userInput = 0;
            do
            {
                Console.Write(str);
            } while (!double.TryParse(Console.ReadLine(), out userInput) || userInput < 0);

            return userInput;
        }

        public static string GetUserInputForPin(string str)
        {
            string userInput = "";
            do
            {
                Console.Write(str);
                userInput = Console.ReadLine();
            } while (userInput.Length != 4);

            return userInput;
        }
    }
}

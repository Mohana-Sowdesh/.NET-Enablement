using System;

namespace CreditCardManagementSystem 
{
    class Program 
    {
        static void Main(string[] args) 
        {   
            IBank bankObject = new BankAdmin();
            Customer customerObject = new Customer();

            while(true) {
                Console.WriteLine("\n\nSelect the user type - \n1. Bank Administrator \n2. Customer");
                string user_choice = Console.ReadLine();

                switch(user_choice) {
                    case "1":
                    {
                        Console.WriteLine("\nHello Bank Administrator!");
                        bankObject.initializeOperation();
                        break;
                    }
                    case "2":
                    {
                        Console.WriteLine("\nHello Customer!");
                        customerObject.initializeOperation((BankAdmin)bankObject);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Please enter a valid choice!!");
                        break;
                    }
                }
            }
        }
    }
}
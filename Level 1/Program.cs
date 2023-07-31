using System;

namespace CreditCardManagementSystem 
{
    class Program 
    {
        static void Main() 
        {   
            Bank bankObject = new Bank();
            BankAdmin bankAdminObject = new BankAdmin();
            Customer customerObject = new Customer();

            while(true) {
                Console.WriteLine("\n\nSelect the user type - \n1. Bank Administrator \n2. Customer");
                string userChoice = Console.ReadLine();

                switch(userChoice) {
                    case "1":
                    {
                        Console.WriteLine("\nHello Bank Administrator!");
                        bankAdminObject.InitializeOperation(bankObject);
                        break;
                    }
                    case "2":
                    {
                        Console.WriteLine("\nHello Customer!");
                        customerObject.InitializeOperation();
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

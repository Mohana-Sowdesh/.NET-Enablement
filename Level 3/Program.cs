using System;

namespace CreditCardManagementSystemLevel2 
{
    class Program 
    {
        public static HDFCBankAdmin hdfcBankAdmin = new HDFCBankAdmin();
        public static SBIBankAdmin sbiBankAdmin = new SBIBankAdmin();
        public static KVBBankAdmin kvbBankAdmin = new KVBBankAdmin();
        static void Main(string[] args) 
        {   
            BankAdmin bankObject = new BankAdmin();
            Customer customerObject = new Customer();

            while(true) {
                Console.WriteLine("\n\nSelect the user type - \n1. Bank Administrator \n2. Customer");
                string user_choice = Console.ReadLine();

                switch(user_choice) {
                    case "1":
                    {
                        bankObject.InitializeOperation(sbiBankAdmin, hdfcBankAdmin, kvbBankAdmin);
                        break;
                    }
                    case "2":
                    {
                        Console.WriteLine("\nHello Customer!");
                        customerObject.InitializeOperation(bankObject, sbiBankAdmin, hdfcBankAdmin, kvbBankAdmin);
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

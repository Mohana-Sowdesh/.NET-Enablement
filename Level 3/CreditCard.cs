using System;

namespace CreditCardManagementSystemLevel2
{
    class CreditCard
    {
        public int CardNumber { get; set; }
        public int Balance {get; set; }
        public int Cvv { get; set; }
        public string Pin {get; set; }
        public string Status { get; set; }
        static void viewBalance()
        {
            Console.WriteLine("Please enter card number: ");
            string inputCardNumber = Console.ReadLine();
        }

        public string CardType { get; set; }
        public int SpendingLimit { get; set; }
    }
}
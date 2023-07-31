using System;

namespace CreditCardManagementSystem3
{
    class CreditCard
    {
        public int CardNumber { get; set; }
        public int Balance {get; set; }
        public int Cvv { get; set; }
        public string Pin {get; set; }
        public string Status { get; set; }
        public string CardType { get; set; }
        public int SpendingLimit { get; set; }
    }
}
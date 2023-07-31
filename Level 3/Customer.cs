using System;
using System.Collections.Generic;

namespace CreditCardManagementSystem3
{
    class Customer
    {
        public static Dictionary<int, int> customerCardCount = new Dictionary<int, int>();
        public int CustomerId { get; set;}
        public string CustomerName { get; set;}
        public List<CreditCard> Cards { get; set;}
        public int CardRequests { get; set;}

        BankHelper bankHelper;
        public void InitializeOperation(SBIBankAdmin sbiBankAdmin, HDFCBankAdmin hdfcBankAdmin, KVBBankAdmin kvbBankAdmin)
        {
            Console.WriteLine("Please choose a bank to perform banking operations: \n1. SBI \n2. HDFC \n3. KVB");
            string userChoice = Console.ReadLine();

            switch(userChoice)
            {
                case "1":
                {
                    bankHelper = new BankHelper(sbiBankAdmin);
                    break;
                }
                case "2":
                {
                    bankHelper = new BankHelper(hdfcBankAdmin);
                    break;
                }
                case "3":
                {
                    bankHelper = new BankHelper(kvbBankAdmin);
                    break;
                }
            }

            Console.WriteLine("Select the operation to perform - \n1. Apply for new credit card" + 
                        "\n2. View balance \n3. Close/block credit card \n4. Purchase items \n5. Logout");
            string customerChoice = Console.ReadLine();

            switch(customerChoice)
            {
                case "1":
                {
                    ApplyNewCreditCard();
                    break;
                }
                case "2":
                {
                    bankHelper.ViewBalanceHelper();
                    break;
                }
                case "3":
                {
                    bankHelper.BlockCreditCardDoer();
                    break;
                }
                case "4":
                {
                    PurchaseItems();
                    break; 
                }
                case "5":
                {
                    Console.WriteLine("Thank you!! You are logged out from the session.");
                    break; 
                }
                default:
                {
                    Console.WriteLine("Please enter a valid choice!!");
                    break;
                }
            }
        }

        public void ApplyNewCreditCard()
        {
            Console.WriteLine("Enter customer unique ID: ");
            int inputID = Convert.ToInt32(Console.ReadLine());
            bankHelper.NewCreditCardHelper(inputID);
        }

        public void PurchaseItems()
        {
            Item itemObject = new Item();
            int purchasedAmt = itemObject.ChooseItems();

            Console.WriteLine("You have purchased for Rs. " + purchasedAmt);
            bankHelper.Spend(purchasedAmt);
        }
    }
}
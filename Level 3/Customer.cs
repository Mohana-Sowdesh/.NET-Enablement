using System;
using System.Collections.Generic;

namespace CreditCardManagementSystemLevel2
{
    class Customer 
    {
        //Properties of Customer class
        public int CustomerId { get; set;}
        public string CustomerName { get; set;}
        public List<CreditCard> Cards { get; set;}
        public int CardRequests { get; set;}
        
        public void InitializeOperation(BankAdmin bankObject, SBIBankAdmin sbiBankAdmin, HDFCBankAdmin hdfcBankAdmin, KVBBankAdmin kvbBankAdmin)
        {
            Console.WriteLine("Please choose a bank to perform banking operations: \n1. SBI \n2. HDFC \n3. KVB");
            string userChoice = Console.ReadLine();
            List<Customer> customersArrayList;

            switch(userChoice)
            {
                case "1":
                {
                    customersArrayList = SBIBankAdmin.sbiCustomersArrayList;
                    break;
                }
                case "2":
                {
                    customersArrayList = HDFCBankAdmin.hdfcCustomersArrayList;
                    break;
                }
                case "3":
                {
                    customersArrayList = KVBBankAdmin.kvbCustomersArrayList;
                    break;
                }
                default:
                {
                    Console.WriteLine("Please enter a valid choice!!");
                    return;
                    break;
                }
            }
            Console.WriteLine("Select the operation to perform - \n1. Apply for new credit card" + 
                        "\n2. View balance \n3. Close/block credit card \n4. Purchase items \n5. Logout");
            string customer_choice = Console.ReadLine();

            switch(customer_choice)
            {
                case "1":
                {
                    ApplyNewCreditCard(bankObject, customersArrayList);
                    break;
                }
                case "2":
                {
                    ViewBalance(bankObject, customersArrayList);
                    break;
                }
                case "3":
                {
                    BlockCreditCard(bankObject, customersArrayList);
                    break;
                }
                case "4":
                {
                    PurchaseItems(bankObject, customersArrayList);
                    break;
                }
                case "5":
                {
                    Console.WriteLine("Thank you!! You are logged out from the session.");
                    break; 
                }
            }
        }
        static void ApplyNewCreditCard(BankAdmin bankObject, List<Customer> customersArrayList)
        {
            Console.WriteLine("Enter Adhar ID: ");
            int inputID = Convert.ToInt32(Console.ReadLine());
            //Checks if the customer ID given by the user is present 
            int index = bankObject.customerFinder(inputID, customersArrayList);
            if(index == -1)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            Customer customer = customersArrayList[index];
            if(customer.Cards.Count == 5)
            {
                Console.WriteLine("Maximum no. of cards limits reached!!");
            }
            customersArrayList[index].CardRequests = customer.CardRequests + 1;
            Console.WriteLine("Thankyou!! Your request is being processed");
        }

        static void ViewBalance(BankAdmin bankObject, List<Customer> customersArrayList)
        {
            Console.WriteLine("Enter Customer ID: ");
            int inputID = Convert.ToInt32(Console.ReadLine());
            //Checks if the customer ID given by the user is present 
            int customerFinderResult = bankObject.customerFinder(inputID, customersArrayList);
            if(customerFinderResult == -1)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            if(customersArrayList[customerFinderResult].Cards.Count == 0)
            {
                Console.WriteLine("No credit card is associated with this account");
                return;
            }
            Console.WriteLine("Enter the number of card : ");
            int inputCardNum = Convert.ToInt32(Console.ReadLine());
            //Checks if the credit card is present 
            int cardFinderResult = bankObject.creditCardFinder(customerFinderResult, inputCardNum, customersArrayList);
            if(cardFinderResult == -1)
            {
                Console.WriteLine("Credit card not found");
                return;
            }
            Console.WriteLine("Balance in card: " + customersArrayList[cardFinderResult].Cards[cardFinderResult].Balance);
        }

        static void BlockCreditCard(BankAdmin bankObject, List<Customer> customersArrayList)
        {
            //Reusing the BlockCreditCard method present in BankAdmin class
            bankObject.BlockCreditCard(customersArrayList);
        }

        static void PurchaseItems(BankAdmin bankObject, List<Customer> customersArrayList)
        {
            Item itemObject = new Item();
            int purchasedAmt = itemObject.chooseItems();

            Console.WriteLine("You have purchased for Rs. " + purchasedAmt);

            //Calling spend method un bankAdmin class
            bankObject.Spend(purchasedAmt, customersArrayList);
        }
    }
}
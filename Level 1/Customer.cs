using System;
using System.Collections.Generic;

namespace CreditCardManagementSystem
{
    class Customer
    {
        public int CustomerId { get; set;}
        public string CustomerName { get; set;}
        public List<CreditCard> Cards { get; set;}
        public int CardRequests { get; set;}
        public void InitializeOperation()
        {
            Console.WriteLine("Select the operation to perform - \n1. Apply for new credit card" + 
                        "\n2. View balance \n3. Close/block credit card \n4. Logout");
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
                    ViewBalance();
                    break;
                }
                case "3":
                {
                    BlockCreditCard();
                    break;
                }
                case "4":
                {
                    Console.WriteLine("Thank you!! You are logged out from the session.");
                    break; 
                }
            }
        }

        public void ApplyNewCreditCard()
        {
            Console.WriteLine("Enter customer unique ID: ");
            int inputID = Convert.ToInt32(Console.ReadLine());

            BankHelper bankHelper = new BankHelper();
            bankHelper.NewCreditCardHelper(inputID);
        }

        public void ViewBalance()
        {
            BankHelper bankHelper = new BankHelper();
            int[] resultArray = bankHelper.BlockCreditCardHelper();
            int customerFinderResult = resultArray[0];
            int cardFinderResult = resultArray[1];
            if(customerFinderResult == -1 || cardFinderResult == -1)
                return;

            Console.WriteLine("Balance in card: " + Bank.customersArrayList[customerFinderResult].Cards[cardFinderResult].Balance);
        }

        public void BlockCreditCard()
        {
            BankHelper bankHelper = new BankHelper();
            int[] resultArray = bankHelper.BlockCreditCardHelper();
            int customerFinderResult = resultArray[0];
            int cardFinderResult = resultArray[1];
            if(customerFinderResult == -1 || cardFinderResult == -1)
                return;
            
            //Getting user's choice 
            Console.WriteLine("Do you want to close or block the card?");
            string userChoice = Console.ReadLine();
            if(userChoice == "block")
            {
                //Changing the status of credit card as 'blocked'
                Bank.customersArrayList[customerFinderResult].Cards[cardFinderResult].Status = "Blocked";
                Console.WriteLine("Card blocked successfully!!");
            }
            else if(userChoice == "close")
            {
                //Changing the status of credit card as 'closed'
                Bank.customersArrayList[customerFinderResult].Cards[cardFinderResult].Status = "Closed";
                Console.WriteLine("Card closed successfully!!");
            }
        }
    }
}
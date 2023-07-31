using System;

namespace CreditCardManagementSystem
{
    class BankAdmin : Bank
    {
        BankHelper bankHelper = new BankHelper();

        public void InitializeOperation(Bank bank)
        {   
            Console.WriteLine("Select the operation to perform - \n1. View all customer data" + 
                    "\n2. View all issued cards \n3. Add new customer \n4. Issue new credit card" +
                    "\n5. View blocked cards \n6. Close/block credit card \n7. Deposit cash \n8. Logout");
            string bankAdminChoice = Console.ReadLine();

            switch(bankAdminChoice)
            {
                case "1":
                {
                    ViewAllCustomerData();
                    break;
                }
                case "2":
                {
                    ViewAllIssuedCards();
                    break;
                }
                case "3":
                {
                    bankHelper.AddNewCustomerHelper(bank);
                    break;
                }
                case "4":
                {
                    bankHelper.IssueNewCreditCardHelper(bank);
                    break;
                }
                case "5":
                {
                    ViewBlockedCards();
                    break;
                }
                case "6":
                {
                    BlockCreditCard();
                    break;
                }
                case "7":
                {
                    Deposit();
                    break;
                }
                case "8":
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

        public void ViewAllCustomerData()
        {
            if(customersArrayList.Count == 0)
            {
                Console.WriteLine("No customers present");
                return;
            }

            foreach(var customer in customersArrayList)
            {
                Console.WriteLine("Name: " + customer.CustomerName + ", Customer ID: " + customer.CustomerId + ", No. of credit cards possessed: " + customer.Cards.Count);
            }
        }
        public void ViewAllIssuedCards()
        {
            Console.WriteLine("Printing all issued cards:");
            //Iterating through the customers_al arraylist to find issued cards
            foreach(var customer in customersArrayList)
            {
                foreach(var card in customer.Cards)
                {
                    Console.WriteLine("Credit card number: " + card.CardNumber + ", Credit card holder name: " + customer.CustomerName + ", Credit card status: " + card.Status);
                }
            }
        }
        public void ViewBlockedCards()
        {
            //Iterating through the customers_al list to find the blocked cards
            foreach(var customer in customersArrayList)
            {
                if(customer.Cards.Count > 0)
                {
                    foreach(var card in customer.Cards)
                    {
                        if(card.Status == "Blocked" || card.Status == "Closed")
                            Console.WriteLine("Customer ID: " + customer.CustomerId + ", Customer Name: " + customer.CustomerName + ", Credit Card Number: " + card.CardNumber + ", Card Status: " + card.Status);
                    }
                }
            }
        }
    }
}
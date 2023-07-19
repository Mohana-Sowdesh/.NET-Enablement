using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CreditCardManagementSystemLevel2 
{
    class BankAdmin : IBank
    {   
        public void InitializeOperation(SBIBankAdmin sbiBankAdmin, HDFCBankAdmin hdfcBankAdmin, KVBBankAdmin kvbBankAdmin)
        {
            Console.WriteLine("Please select your bank: \n1. SBI \n2. HDFC \n3. KVB");
            string bankChoice = Console.ReadLine();

            switch(bankChoice)
            {
                case "1":
                {   
                    sbiBankAdmin.SelectOperation();
                    break;
                }
                case "2":
                {   
                    hdfcBankAdmin.SelectOperation();
                    break;
                }
                case "3":
                {
                    kvbBankAdmin.SelectOperation();
                    break;
                }
                default:
                {
                    break;
                }
            }
        }
        public void ViewAllCustomerData(List<Customer> customerArrayList)
        {
            if(customerArrayList.Count == 0)
                Console.WriteLine("No customers present");

            foreach(var customer in customerArrayList)
            {
                Console.WriteLine("Name: " + customer.CustomerName + ", Customer ID: " + customer.CustomerId + ", No. of credit cards possessed: " + customer.Cards.Count);
            }
        }

        public void ViewAllIssuedCards(List<Customer> customerArrayList)
        {
            if(customerArrayList.Count == 0)
            {
                Console.WriteLine("No cards issued");
                return;
            }

            Console.WriteLine("Printing all issued cards:");
            //Iterating through the customerArrayList arraylist to find issued cards
            foreach(var customer in customerArrayList)
            {
                foreach(var card in customer.Cards)
                {
                    Console.WriteLine("Credit card number: " + card.CardNumber + ", Credit card holder name: " + customer.CustomerName + ", Credit card status: " + card.Status + ", Card Type: " + card.CardType);
                }
            }
        }

        public void AddNewCustomer(List<Customer> customerArrayList)
        {
            Console.WriteLine("Enter customer name: ");
            string customerName = Console.ReadLine();

            Random random = new Random();
            //Creating random number for customer ID
            int customerId = random.Next(1, 10000);

            //Creating a new Customer class object and adding it to customerArrayList arraylist
            customerArrayList.Add(new Customer(){CustomerId = customerId, CustomerName = customerName, Cards = new List<CreditCard>(), CardRequests = 0});
            Console.WriteLine("Customer added successfully!!");
        }

        public void IssueNewCreditCard(List<Customer> customerArrayList)
        {
            Console.WriteLine("Enter customer unique ID: ");
            int inputId = Convert.ToInt32(Console.ReadLine());
            //Checking if customer is present
            int result = customerFinder(inputId, customerArrayList);

            if(result == -1)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            Customer customer = (Customer)customerArrayList[result];
            while(customer.CardRequests > 0)
            {
                //Checks if the maximum card limit is not reached
                if(customer.Cards.Count < 5)
                {
                    Random random = new Random();
                    string[] choices = GetCardTypeChoice();
                    if(choices[1]==null)
                     return;
                    //Creating a random number for card number and CVV
                    int cardNum = random.Next(1, 1000000);
                    int cvv = random.Next(1, 1000);
                    CreditCard newCard = new CreditCard(){CardNumber = cardNum, Balance = 0, Cvv = cvv, Pin = "6789", Status = "Active", CardType = choices[0], SpendingLimit = Convert.ToInt32(choices[1])};
                    customerArrayList[result].Cards.Add(newCard);
                    customer.CardRequests--;
                    Console.WriteLine("Card count:"+customerArrayList[result].Cards.Count);
                    Console.WriteLine("Credit card issued successfully!! Card number: " + cardNum);
                }
                else {
                    Console.WriteLine("Maximum no. of cards limits reached!!");
                }
            }
        }

        public string[] GetCardTypeChoice()
        {
            Console.WriteLine("Select a card type: \n1. Platinum \n2. Diamond \n3. Gold");
            string cardChoice = Console.ReadLine();
            string[] choices = new string[2];
            switch(cardChoice)
            {
                case "1":
                {
                    choices[0] = "Platinum";
                    choices[1] = "500000";
                    break;
                }
                case "2":
                {
                    choices[0] = "Diamond";
                    choices[1] = "200000";
                    break;
                }
                case "3":
                {
                    choices[0] = "Gold";
                    choices[1] = "100000";
                    break;
                }
                default:
                {
                    Console.WriteLine("Please enter correct choice!!");
                    break;
                }
            }
            return choices;
        }
        public void ViewBlockedCards(List<Customer> customerArrayList)
        {
            //Iterating through the customerArrayList list to find the blocked cards
            foreach(var customer in customerArrayList)
            {
                if(customer.Cards.Count>0)
                {
                    foreach(var card in customer.Cards)
                    {
                        if(card.Status == "Blocked")
                            Console.WriteLine("Customer ID: " + customer.CustomerId + ", Customer Name: " + customer.CustomerName + ", Credit Card Number: " + card.CardNumber + ", Card Status: " + card.Status);
                    }
                }
            }
        }

        public void BlockCreditCard(List<Customer> customerArrayList)
        {
            Console.WriteLine("Enter customer unique ID: ");
            int inputId = Convert.ToInt32(Console.ReadLine());
            //Checking if customer is present
            int customerFinderResult = customerFinder(inputId, customerArrayList);
            if(customerFinderResult == -1)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            Console.WriteLine("Enter the card number that needs to be blocked: ");
            int inputCardNum = Convert.ToInt32(Console.ReadLine());
            //Checking if the credit card is present
            int cardFinderResult = creditCardFinder(customerFinderResult, inputCardNum, customerArrayList);
            if(cardFinderResult == -1)
            {
                Console.WriteLine("Credit card not found");
                return;
            }
            Console.WriteLine("Do you want to close or block the card?");
            string usr_choice = Console.ReadLine();
            if(usr_choice == "block")
            {
                //Changing the status of credit card as 'blocked'
                customerArrayList[customerFinderResult].Cards[cardFinderResult].Status = "Blocked";
                Console.WriteLine(inputCardNum + " card blocked successfully");
            }
            else if(usr_choice == "close")
            {
                //Changing the status of credit card as 'closed'
                customerArrayList[customerFinderResult].Cards[cardFinderResult].Status = "Closed";
                Console.WriteLine(inputCardNum + " card closed successfully");
            }
        }

        public void Deposit(List<Customer> customerArrayList)
        {
            Console.WriteLine("Enter customer unique ID: ");
            int inputId = Convert.ToInt32(Console.ReadLine());
            //Checking if customer is present
            int customerFinderResult = customerFinder(inputId, customerArrayList);
            if(customerFinderResult == -1)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            Console.WriteLine("Enter the card number: ");
            int inputCardNum = Convert.ToInt32(Console.ReadLine());
            //Checking if the credit card is present
            int cardFinderResult = creditCardFinder(customerFinderResult, inputCardNum, customerArrayList);
            if(cardFinderResult == -1)
            {
                Console.WriteLine("Credit card not found");
                return;
            }
            Console.WriteLine("Enter the amount to be deposited: ");
            int amtToDeposit = Convert.ToInt32(Console.ReadLine());
            customerArrayList[customerFinderResult].Cards[cardFinderResult].Balance += amtToDeposit;
            Console.WriteLine("Amount deposited!!"); 
        }

        public void Spend(int purchasedAmt, List<Customer> customerArrayList)
        {
            Console.WriteLine("Enter customer unique ID: ");
            int inputId = Convert.ToInt32(Console.ReadLine());
            //Checking if customer is present
            int customerFinderResult = customerFinder(inputId, customerArrayList);
            if(customerFinderResult == -1)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            Console.WriteLine("Enter the card number: ");
            int inputCardNum = Convert.ToInt32(Console.ReadLine());
            //Checking if the credit card is present
            int cardFinderResult = creditCardFinder(customerFinderResult, inputCardNum, customerArrayList);
            if(cardFinderResult == -1)
            {
                Console.WriteLine("Credit card not found");
                return;
            }
            int balance = customerArrayList[customerFinderResult].Cards[cardFinderResult].Balance;

            //Checking if balance is greater than purchased amount
            if(balance < purchasedAmt)
            {
                Console.WriteLine("Sorry!! Your balance is not sufficient to make the payment");
                return;
            }
            else if(purchasedAmt > customerArrayList[customerFinderResult].Cards[cardFinderResult].SpendingLimit)
            {
                Console.WriteLine("Your card's spending limit is less. Sorry!! Payment cannot be processed!!");
            }
            else
            {
                customerArrayList[customerFinderResult].Cards[cardFinderResult].Balance = balance - purchasedAmt;
                Console.WriteLine("Thankyou!! Payment Success!! Current balance = " + customerArrayList[customerFinderResult].Cards[cardFinderResult].Balance);
            }
        }

        public void PrintBlockedAndClosedCards(List<Customer> customerArrayList)
        {
            //Using stream writer to write blocked and closed cards in a file
            using (StreamWriter sw = new StreamWriter("Closed & Blocked cards.txt"))
            {
                foreach(var customer in customerArrayList)
                {
                    if(customer.Cards.Count>0)
                    {
                        foreach(var card in customer.Cards)
                        {
                            if(card.Status == "Blocked" || card.Status == "Closed")
                                sw.WriteLine("Customer ID: " + customer.CustomerId + ", Customer Name: " + customer.CustomerName + ", Credit Card Number: " + card.CardNumber + ", Card Status: " + card.Status);
                        }
                    }
                }
            }
        }

        public int customerFinder(int custId, List<Customer> customerArrayList)
        {
            int flag = 0;
            int i = 0;

            for(i=0; i<customerArrayList.Count; i++)
            {
                Customer customer = (Customer)customerArrayList[i];
                //Checks if the customer ID given by the user is present 
                if(customer.CustomerId == custId)
                {
                    flag = 1;
                    break;
                }
            }
            if(flag == 0)
                return -1;
            return i;
        }

        public int creditCardFinder(int customerIndex, int cardNumber, List<Customer> customerArrayList)
        {
            int flag = 0;
            int i = 0;

            for(i=0; i<customerArrayList[customerIndex].Cards.Count; i++)
            {
                //Checks if the credit card number given by the user is present 
                if(customerArrayList[customerIndex].Cards[i].CardNumber == cardNumber)
                {
                    flag = 1;
                    break;
                }
            }
            if(flag == 0)
                return -1;
            return i;
        }
    }
}    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CreditCardManagementSystemLevel2 
{
    class BankAdmin : IBank
    { 
        //Static arrayList containing all customers so that object reference need not passed everytime 
        public static List<Customer> customers_al = new List<Customer>();  
        public void viewAllCustomerData()
        {
            if(customers_al.Count == 0)
                Console.WriteLine("No customers present");

            foreach(var customer in customers_al)
            {
                Console.WriteLine("Name: " + customer.CustomerName + ", Customer ID: " + customer.CustomerId + ", No. of credit cards possessed: " + customer.Cards.Count);
            }
        }

        public void viewAllIssuedCards()
        {
            if(customers_al.Count == 0)
            {
                Console.WriteLine("No cards issued");
                return;
            }

            Console.WriteLine("Printing all issued cards:");
            //Iterating through the customers_al arraylist to find issued cards
            foreach(var customer in customers_al)
            {
                foreach(var card in customer.Cards)
                {
                    Console.WriteLine("Credit card number: " + card.CardNumber + ", Credit card holder name: " + customer.CustomerName + ", Credit card status: " + card.Status);
                }
            }
        }

        public void addNewCustomer()
        {
            Console.WriteLine("Enter customer name: ");
            string customerName = Console.ReadLine();

            Random random = new Random();
            //Creating random number for customer ID
            int customerId = random.Next(1, 10000);

            //Creating a new Customer class object and adding it to customers_al arraylist
            customers_al.Add(new Customer(){CustomerId = customerId, CustomerName = customerName, Cards = new List<CreditCard>(), CardRequests = 0});
            Console.WriteLine("Customer added successfully!!");
        }

        public void issueNewCreditCard()
        {
            Console.WriteLine("Enter customer unique ID: ");
            int inputId = Convert.ToInt32(Console.ReadLine());
            //Checking if customer is present
            int result = customerFinder(inputId);

            if(result == -1)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            Customer customer = (Customer)customers_al[result];
            while(customer.CardRequests > 0)
            {
                //Checks if the maximum card limit is not reached
                if(customer.Cards.Count < 5)
                {
                    Random random = new Random();
                    //Creating a random number for card number and CVV
                    int cardNum = random.Next(1, 1000000);
                    int cvv = random.Next(1, 1000);
                    CreditCard newCard = new CreditCard(){CardNumber = cardNum, Balance = 0, Cvv = cvv, Pin = "6789", Status = "Active"};
                    customers_al[result].Cards.Add(newCard);
                    customer.CardRequests--;
                    Console.WriteLine("Card count:"+customers_al[result].Cards.Count);
                    Console.WriteLine("Credit card issued successfully!! Card number: " + cardNum);
                }
                else {
                    Console.WriteLine("Maximum no. of cards limits reached!!");
                }
            }
        }

        public void viewBlockedCards()
        {
            //Iterating through the customers_al list to find the blocked cards
            foreach(var customer in customers_al)
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

        public void blockCreditCard()
        {
            Console.WriteLine("Enter customer unique ID: ");
            int inputId = Convert.ToInt32(Console.ReadLine());
            //Checking if customer is present
            int customerFinderResult = customerFinder(inputId);
            if(customerFinderResult == -1)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            Console.WriteLine("Enter the card number that needs to be blocked: ");
            int inputCardNum = Convert.ToInt32(Console.ReadLine());
            //Checking if the credit card is present
            int cardFinderResult = creditCardFinder(customerFinderResult, inputCardNum);
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
                customers_al[customerFinderResult].Cards[cardFinderResult].Status = "Blocked";
                Console.WriteLine(inputCardNum + " card blocked successfully");
            }
            else if(usr_choice == "close")
            {
                //Changing the status of credit card as 'closed'
                customers_al[customerFinderResult].Cards[cardFinderResult].Status = "Closed";
                Console.WriteLine(inputCardNum + " card closed successfully");
            }
        }

        public void deposit()
        {
            Console.WriteLine("Enter customer unique ID: ");
            int inputId = Convert.ToInt32(Console.ReadLine());
            //Checking if customer is present
            int customerFinderResult = customerFinder(inputId);
            if(customerFinderResult == -1)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            Console.WriteLine("Enter the card number: ");
            int inputCardNum = Convert.ToInt32(Console.ReadLine());
            //Checking if the credit card is present
            int cardFinderResult = creditCardFinder(customerFinderResult, inputCardNum);
            if(cardFinderResult == -1)
            {
                Console.WriteLine("Credit card not found");
                return;
            }
            Console.WriteLine("Enter the amount to be deposited: ");
            int amtToDeposit = Convert.ToInt32(Console.ReadLine());
            customers_al[customerFinderResult].Cards[cardFinderResult].Balance += amtToDeposit;
            Console.WriteLine("Amount deposited!!"); 
        }

        public void spend(int purchasedAmt)
        {
            Console.WriteLine("Enter customer unique ID: ");
            int inputId = Convert.ToInt32(Console.ReadLine());
            //Checking if customer is present
            int customerFinderResult = customerFinder(inputId);
            if(customerFinderResult == -1)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            Console.WriteLine("Enter the card number: ");
            int inputCardNum = Convert.ToInt32(Console.ReadLine());
            //Checking if the credit card is present
            int cardFinderResult = creditCardFinder(customerFinderResult, inputCardNum);
            if(cardFinderResult == -1)
            {
                Console.WriteLine("Credit card not found");
                return;
            }
            int balance = customers_al[customerFinderResult].Cards[cardFinderResult].Balance;

            //Checking if balance is greater than purchased amount
            if(balance < purchasedAmt)
            {
                Console.WriteLine("Sorry!! Your balance is not sufficient to make the payment");
                return;
            }
            else
            {
                customers_al[customerFinderResult].Cards[cardFinderResult].Balance = balance - purchasedAmt;
                Console.WriteLine("Thankyou!! Payment Success!! Current balance = " + customers_al[customerFinderResult].Cards[cardFinderResult].Balance);
            }
        }

        public void printBlockedAndClosedCards()
        {
            //Using stream writer to write blocked and closed cards in a file
            using (StreamWriter sw = new StreamWriter("Closed & Blocked cards.txt"))
            {
                foreach(var customer in customers_al)
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

        public int customerFinder(int custId)
        {
            int flag = 0;
            int i = 0;

            for(i=0; i<customers_al.Count; i++)
            {
                Customer customer = (Customer)customers_al[i];
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

        public int creditCardFinder(int customerIndex, int cardNumber)
        {
            int flag = 0;
            int i = 0;

            for(i=0; i<customers_al[customerIndex].Cards.Count; i++)
            {
                //Checks if the credit card number given by the user is present 
                if(customers_al[customerIndex].Cards[i].CardNumber == cardNumber)
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

using System;

namespace CreditCardManagementSystem3
{
    class BankAdmin : Bank
    {
        public void InitializeOperation(SBIBankAdmin sbiBankAdmin, HDFCBankAdmin hdfcBankAdmin, KVBBankAdmin kvbBankAdmin)
        {
            Console.WriteLine("Please select your bank: \n1. SBI \n2. HDFC \n3. KVB");
            string bankChoice = Console.ReadLine();

            switch(bankChoice)
            {
                case "1":
                {   
                    sbiBankAdmin.SelectOperation(sbiBankAdmin);
                    break;
                }
                case "2":
                {   
                    hdfcBankAdmin.SelectOperation(hdfcBankAdmin);
                    break;
                }
                case "3":
                {
                    kvbBankAdmin.SelectOperation(kvbBankAdmin);
                    break;
                }
                default:
                {
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

        public void PrintBlockedAndClosedCards()
        {
            //Using stream writer to write blocked and closed cards in a file
            using (StreamWriter sw = new StreamWriter("Closed & Blocked cards.txt"))
            {
                foreach(var customer in customersArrayList)
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
    }
}
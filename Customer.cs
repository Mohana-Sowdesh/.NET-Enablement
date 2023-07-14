using System;

namespace CreditCardManagementSystem 
{
    class Customer 
    {
        //Properties of Customer class
        public int CustomerId { get; set;}
        public string CustomerName { get; set;}
        public List<CreditCard> Cards { get; set;}
        public int CardRequests { get; set;}
        
        public void initializeOperation(BankAdmin bankObject)
        {
            Console.WriteLine("Select the operation to perform - \n1. Apply for new credit card" + 
                        "\n2. View balance \n3. Close/block credit card \n4. Logout");
            string customer_choice = Console.ReadLine();

            switch(customer_choice)
            {
                case "1":
                {
                    applyNewCreditCard(bankObject);
                    break;
                }
                case "2":
                {
                    viewBalance(bankObject);
                    break;
                }
                case "3":
                {
                    blockCreditCard(bankObject);
                    break;
                }
                case "4":
                {
                    Console.WriteLine("Thank you!! You are logged out from the session.");
                    break; 
                }
            }
        }
        static void applyNewCreditCard(BankAdmin bankObject)
        {
            Console.WriteLine("Enter Adhar ID: ");
            int inputID = Convert.ToInt32(Console.ReadLine());
            //Checks if the customer ID given by the user is present 
            int index = bankObject.customerFinder(inputID);
            if(index == -1)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            Customer customer = BankAdmin.customers_al[index];
            if(customer.Cards.Count == 5)
            {
                Console.WriteLine("Maximum no. of cards limits reached!!");
            }
            BankAdmin.customers_al[index].CardRequests = customer.CardRequests + 1;
            Console.WriteLine("Thankyou!! Your request is being processed");
        }

        static void viewBalance(BankAdmin bankObject)
        {
            Console.WriteLine("Enter Adhar ID: ");
            int inputID = Convert.ToInt32(Console.ReadLine());
            //Checks if the customer ID given by the user is present 
            int customerFinderResult = bankObject.customerFinder(inputID);
            if(customerFinderResult == -1)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            Console.WriteLine("Enter the number of card : ");
            int inputCardNum = Convert.ToInt32(Console.ReadLine());
            //Checks if the credit card is present 
            int cardFinderResult = bankObject.creditCardFinder(customerFinderResult, inputCardNum);
            if(cardFinderResult == -1)
            {
                Console.WriteLine("Credit card not found");
                return;
            }
            Console.WriteLine("Balance in card: " + BankAdmin.customers_al[cardFinderResult].Cards[cardFinderResult].Balance);
        }

        static void blockCreditCard(BankAdmin bankObject)
        {
            //Reusing the blockCreditCard method present in BankAdmin class
            bankObject.blockCreditCard();
        }
    }
}

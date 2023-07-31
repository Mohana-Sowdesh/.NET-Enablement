using System;

namespace CreditCardManagementSystem
{
    class BankHelper
    {
        public void AddNewCustomerHelper(Bank bank)
        {
            Console.WriteLine("Enter customer name: ");
            string customerName = Console.ReadLine();

            //Using Adhar ID to find customer across all banks
            Console.WriteLine("Enter customer Adhar ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            bank.AddNewCustomer(customerId, customerName);
        }

        public void IssueNewCreditCardHelper(Bank bank)
        {
            Console.WriteLine("Enter customer unique ID: ");
            int inputId = Convert.ToInt32(Console.ReadLine());
            
            //Checking if customer is present
            int result = CustomerFinder(inputId);
            if(result == -1)
            {
                Console.WriteLine("Customer not found");
                return;
            }
            else 
            {
                bank.IssueNewCreditCard(result, inputId);
            }
        }
        
        public int CustomerFinder(int custId)
        {
            int flag = 0;
            int i = 0;

            for(i=0; i < Bank.customersArrayList.Count; i++)
            {
                //Checks if the customer ID given by the user is present 
                if(Bank.customersArrayList[i].CustomerId == custId)
                {
                    flag = 1;
                    break;
                }
            }
            if(flag == 0)
                return -1;
            return i;
        }

        public int CreditCardFinder(int customerIndex, int cardNumber)
        {
            int flag = 0;
            int i;

            for(i = 0; i < Bank.customersArrayList[customerIndex].Cards.Count; i++)
            {
                //Checks if the credit card number given by the user is present 
                if(Bank.customersArrayList[customerIndex].Cards[i].CardNumber == cardNumber  && Bank.customersArrayList[customerIndex].Cards[i].Status== "Active")
                {
                    flag = 1;
                    break;
                }
            }
            if(flag == 0)
                return -1;
            return i;
        }

        public void NewCreditCardHelper(int inputId)
        {
            //Checks if the customer ID given by the user is present 
            int index = CustomerFinder(inputId);
            if(index == -1)
            {
                Console.WriteLine("Customer not found");
                return;
            }

            int cardRequestsCount = Bank.customersArrayList[index].CardRequests;
            if(cardRequestsCount >= 5)
            {
                Console.WriteLine("Maximum no. of cards limit reached!!");
                return;
            }
            Bank.customersArrayList[index].CardRequests = Bank.customersArrayList[index].CardRequests + 1;
            Console.WriteLine("Thankyou!! Your request is being processed");
        }

        public int[] BlockCreditCardHelper()
        {
            int[] returnArray = {-1,-1};
            Console.WriteLine("Enter customer unique ID: ");
            int inputId = Convert.ToInt32(Console.ReadLine());

            //Checking if customer is present
            int customerFinderResult = CustomerFinder(inputId);
            if(customerFinderResult == -1)
                Console.WriteLine("Customer not found");
            
            Console.WriteLine("Enter the card number: ");
            int inputCardNum = Convert.ToInt32(Console.ReadLine());

            //Checking if the credit card is present
            int cardFinderResult = CreditCardFinder(customerFinderResult, inputCardNum);
            if(cardFinderResult == -1)
                Console.WriteLine("Credit card not found");
    
            returnArray[0] = customerFinderResult;
            returnArray[1] = cardFinderResult;
            return returnArray;
        }
    }
}
using System;

namespace CreditCardManagementSystem3
{
    class BankHelper
    {
        Bank bank;

        public BankHelper(Bank bank){
            this.bank = bank;
        }
        public void AddNewCustomerHelper()
        {
            Console.WriteLine("Enter customer name: ");
            string customerName = Console.ReadLine();

            //Using Adhar ID to find customer across all banks
            Console.WriteLine("Enter customer Adhar ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            bank.AddNewCustomer(customerId, customerName);
        }

        public void IssueNewCreditCardHelper()
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
  
            for(i=0; i < bank.customersArrayList.Count; i++)
            {
                //Checks if the customer ID given by the user is present 
                if(bank.customersArrayList[i].CustomerId == custId)
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

            for(i = 0; i < bank.customersArrayList[customerIndex].Cards.Count; i++)
            {
                //Checks if the credit card number given by the user is present 
                if(bank.customersArrayList[customerIndex].Cards[i].CardNumber == cardNumber  && bank.customersArrayList[customerIndex].Cards[i].Status== "Active")
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

            int cardRequestsCount = bank.customersArrayList[index].CardRequests;
            if(cardRequestsCount >= 5)
            {
                Console.WriteLine("Maximum no. of cards limit reached!!");
                return;
            }
            bank.customersArrayList[index].CardRequests = bank.customersArrayList[index].CardRequests + 1;
            System.Console.WriteLine("Card count {0}", Customer.customerCardCount[inputId]);
            System.Console.WriteLine(bank.customersArrayList[index].CardRequests);
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

        public int CheckPin(int customerFinderResult, int cardFinderResult)
        {
            System.Console.WriteLine("Please enter your card pin: ");
            string userEnteredPin = Console.ReadLine();

            if(userEnteredPin == bank.customersArrayList[customerFinderResult].Cards[cardFinderResult].Pin)
                return 1;
            else
            {
                System.Console.WriteLine("You have entered wrong pin!!");
                return -1;
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

        public void CheckOrCreateOne(int inputId)
        {
            if(!Customer.customerCardCount.ContainsKey(inputId))
                Customer.customerCardCount.Add(inputId, 0);
        }

        public void ViewBalanceHelper()
        {
            int[] resultArray = BlockCreditCardHelper();
            int customerFinderResult = resultArray[0];
            int cardFinderResult = resultArray[1];
            if(customerFinderResult == -1 || cardFinderResult == -1)
                return;

            Console.WriteLine("Balance in card: " + bank.customersArrayList[customerFinderResult].Cards[cardFinderResult].Balance);
        }

        public void BlockCreditCardDoer()
        {
            int[] resultArray = BlockCreditCardHelper();
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
                bank.customersArrayList[customerFinderResult].Cards[cardFinderResult].Status = "Blocked";
                Console.WriteLine("Card blocked successfully!!");
            }
            else if(userChoice == "close")
            {
                //Changing the status of credit card as 'closed'
                bank.customersArrayList[customerFinderResult].Cards[cardFinderResult].Status = "Closed";
                Console.WriteLine("Card closed successfully!!");
            }
        }

        public void Spend(int purchasedAmt)
        {
            int[] resultArray = BlockCreditCardHelper();
            int customerFinderResult = resultArray[0];
            int cardFinderResult = resultArray[1];
            if(customerFinderResult == -1 || cardFinderResult == -1)
                return;

            int balance = bank.customersArrayList[customerFinderResult].Cards[cardFinderResult].Balance;

            int pinResult = CheckPin(customerFinderResult, cardFinderResult);

            if(pinResult == -1)
                return;
                
            //Checking if balance is greater than purchased amount
            if(balance < purchasedAmt)
            {
                Console.WriteLine("Sorry!! Your balance is not sufficient to make the payment");
                return;
            }
            else
            {
                bank.customersArrayList[customerFinderResult].Cards[cardFinderResult].Balance = balance - purchasedAmt;
                Console.WriteLine("Thankyou!! Payment Success!! Current balance = " + bank.customersArrayList[customerFinderResult].Cards[cardFinderResult].Balance);
            }
        }
    }
}
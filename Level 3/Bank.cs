using System;

namespace CreditCardManagementSystem3
{
    class Bank : IBank
    {
        public List<Customer> customersArrayList = new List<Customer>();
        
        public void AddNewCustomer(int customerId, string customerName)
        {
            //Creating a new Customer class object and adding it to customers_al arraylist
            customersArrayList.Add(new Customer(){CustomerId = customerId, CustomerName = customerName, Cards = new List<CreditCard>(), CardRequests = 0});
            Console.WriteLine("Customer added successfully!!");
        }

        public void IssueNewCreditCard(int result, int inputId)
        {
            BankHelper bankHelper = new BankHelper(this);
            Customer customer = customersArrayList[result];
            bankHelper.CheckOrCreateOne(inputId);

            while(customer.CardRequests > 0)
            {
                //Checks if the maximum card limit is not reached
                if(customer.Cards.Count < 5 && Customer.customerCardCount[inputId] < 5)
                {
                    Random random = new Random();
                    string[] choices = bankHelper.GetCardTypeChoice();
                    if(choices[1]==null)
                        return;

                    //Creating a random number for card number and CVV
                    int cardNum = random.Next(1, 1000000);
                    int cvv = random.Next(1, 1000);
                    CreditCard newCard = new CreditCard(){CardNumber = cardNum, Balance = Convert.ToInt32(choices[1]), Cvv = cvv, Pin = "6789", Status = "Active", CardType = choices[0], SpendingLimit = Convert.ToInt32(choices[1])};
                    customersArrayList[result].Cards.Add(newCard);
                    Customer.customerCardCount[inputId] += 1;
                    System.Console.WriteLine("Card count {0}", Customer.customerCardCount[inputId]);
                    customer.CardRequests--;
                    Console.WriteLine("Card count:" + customersArrayList[result].Cards.Count);
                    Console.WriteLine("Credit card issued successfully!! Card number: {0}", cardNum);
                }
                else {
                    Console.WriteLine("Maximum no. of cards limits reached!!");
                    return;
                }
            }
        }

        public void BlockCreditCard()
        {
            BankHelper bankHelper = new BankHelper(this);
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
                customersArrayList[customerFinderResult].Cards[cardFinderResult].Status = "Blocked";
                Console.WriteLine("Card blocked successfully!!");
            }
            else if(userChoice == "close")
            {
                //Changing the status of credit card as 'closed'
                customersArrayList[customerFinderResult].Cards[cardFinderResult].Status = "Closed";
                Console.WriteLine("Card closed successfully!!");
            }
        }

        public void Deposit()
        {
            BankHelper bankHelper = new BankHelper(this);
            int[] resultArray = bankHelper.BlockCreditCardHelper();
            int customerFinderResult = resultArray[0];
            int cardFinderResult = resultArray[1];
            if(customerFinderResult == -1 || cardFinderResult == -1)
                return;

            Console.WriteLine("Enter the amount to be deposited: ");
            int amtToDeposit = Convert.ToInt32(Console.ReadLine());
            customersArrayList[customerFinderResult].Cards[cardFinderResult].Balance += amtToDeposit;
            Console.WriteLine("Amount deposited!!"); 
        }
    }
}
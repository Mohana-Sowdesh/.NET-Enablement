interface IBank 
{
    public void initializeOperation()
    {
        Console.WriteLine("Select the operation to perform - \n1. View all customer data" + 
                    "\n2. View all issued cards \n3. Add new customer \n4. Issue new credit card" +
                    "\n5. View blocked cards \n6. Close/block credit card \n7. Deposit cash \n8. Logout");
        string bank_admin_choice = Console.ReadLine();

        switch(bank_admin_choice)
        {
            case "1":
            {
                viewAllCustomerData();
                break;
            }
            case "2":
            {
                viewAllIssuedCards();
                break;
            }
            case "3":
            {
                addNewCustomer();
                break;
            }
            case "4":
            {
                issueNewCreditCard();
                break;
            }
            case "5":
            {
                viewBlockedCards();
                break;
            }
            case "6":
            {
                blockCreditCard();
                break;
            }
            case "7":
            {
                deposit();
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

    void viewAllCustomerData();
    void viewAllIssuedCards();
    void addNewCustomer();
    void issueNewCreditCard();
    void viewBlockedCards();
    void blockCreditCard();
    void deposit();
}
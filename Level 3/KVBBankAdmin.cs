using System.Text;
using System.IO;

namespace CreditCardManagementSystem3
{
    class KVBBankAdmin : BankAdmin
    {
        public void SelectOperation(KVBBankAdmin bank)
        {   
            BankHelper bankHelper = new BankHelper(bank);
            Console.WriteLine("Select the operation to perform - \n1. View all customer data" + 
                    "\n2. View all issued cards \n3. Add new customer \n4. Issue new credit card" +
                    "\n5. View blocked cards \n6. Close/block credit card \n7. Deposit cash \n8. Print blocked and closed credit cards \n9. Logout");
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
                    bankHelper.AddNewCustomerHelper();
                    break;
                }
                case "4":
                {
                    bankHelper.IssueNewCreditCardHelper();
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
                    PrintBlockedAndClosedCards();
                    break; 
                }
                case "9":
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
    }
}
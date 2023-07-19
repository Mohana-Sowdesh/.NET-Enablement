using System.Text;
using System.IO;

namespace CreditCardManagementSystemLevel2 
{
    class SBIBankAdmin : BankAdmin
    {
        //Static arrayList containing all customers so that object reference need not passed everytime 
        public static List<Customer> sbiCustomersArrayList = new List<Customer>();
        public void SelectOperation()
        {
            Console.WriteLine("Select the operation to perform - \n1. View all customer data" + 
                        "\n2. View all issued cards \n3. Add new customer \n4. Issue new credit card" +
                        "\n5. View blocked cards \n6. Close/block credit card \n7. Deposit cash \n8. Print blocked & closed card details \n9. Logout");
            string bank_admin_choice = Console.ReadLine();

            switch(bank_admin_choice)
            {
                case "1":
                {
                    ViewAllCustomerData(sbiCustomersArrayList);
                    break;
                }
                case "2":
                {
                    ViewAllIssuedCards(sbiCustomersArrayList);
                    break;
                }
                case "3":
                {
                    AddNewCustomer(sbiCustomersArrayList);
                    break;
                }
                case "4":
                {
                    IssueNewCreditCard(sbiCustomersArrayList);
                    break;
                }
                case "5":
                {
                    ViewBlockedCards(sbiCustomersArrayList);
                    break;
                }
                case "6":
                {
                    BlockCreditCard(sbiCustomersArrayList);
                    break;
                }
                case "7":
                {
                    Deposit(sbiCustomersArrayList);
                    break;
                }
                case "8":
                {
                    PrintBlockedAndClosedCards(sbiCustomersArrayList);
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
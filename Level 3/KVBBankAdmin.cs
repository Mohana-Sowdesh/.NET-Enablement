using System.Text;
using System.IO;

namespace CreditCardManagementSystemLevel2 
{
    class KVBBankAdmin : BankAdmin
    {
        //Static arrayList containing all customers so that object reference need not passed everytime 
        public static List<Customer> kvbCustomersArrayList = new List<Customer>();
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
                    ViewAllCustomerData(kvbCustomersArrayList);
                    break;
                }
                case "2":
                {
                    ViewAllIssuedCards(kvbCustomersArrayList);
                    break;
                }
                case "3":
                {
                    AddNewCustomer(kvbCustomersArrayList);
                    break;
                }
                case "4":
                {
                    IssueNewCreditCard(kvbCustomersArrayList);
                    break;
                }
                case "5":
                {
                    ViewBlockedCards(kvbCustomersArrayList);
                    break;
                }
                case "6":
                {
                    BlockCreditCard(kvbCustomersArrayList);
                    break;
                }
                case "7":
                {
                    Deposit(kvbCustomersArrayList);
                    break;
                }
                case "8":
                {
                    PrintBlockedAndClosedCards(kvbCustomersArrayList);
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
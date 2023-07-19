using System;
namespace CreditCardManagementSystemLevel2 
{
    interface IBank 
    {
        void ViewAllCustomerData(List<Customer> customerArrayList);
        void ViewAllIssuedCards(List<Customer> customerArrayList);
        void AddNewCustomer(List<Customer> customerArrayList);
        void IssueNewCreditCard(List<Customer> customerArrayList);
        void ViewBlockedCards(List<Customer> customerArrayList);
        void BlockCreditCard(List<Customer> customerArrayList);
        void Deposit(List<Customer> customerArrayList);
        void Spend(int purchasedAmt, List<Customer> customerArrayList);
        void PrintBlockedAndClosedCards(List<Customer> customerArrayList);
    }
}
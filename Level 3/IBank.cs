namespace CreditCardManagementSystem3
{
    interface IBank 
    {
        void AddNewCustomer(int customerId, string customerName);
        void IssueNewCreditCard(int result, int inputId);
        void BlockCreditCard();
        void Deposit();
    }
}
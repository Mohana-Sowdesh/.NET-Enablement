using System;

namespace CreditCardManagementSystemLevel2
{
    class Item
    {
        public void listItems()
        {
            Console.WriteLine("The items available for purchase are: ");
            Console.WriteLine("1. Rice - Rs. 125 \n2. Dal - Rs. 70 \n3. Grapes - Rs. 50");
        }

        public int chooseItems()
        {
            Item itemObject = new Item();
            itemObject.listItems();

            int sum = 0;
            while(true)
            {
                Console.WriteLine("Enter the number of item to be purchased: ");
                string usr_item_choice = Console.ReadLine();

                switch(usr_item_choice)
                {
                    case "1":
                    {
                        sum += 125;
                        break;
                    }
                    case "2":
                    {
                        sum += 70;
                        break;
                    }
                    case "3":
                    {
                        sum += 50;
                        break;
                    }
                    case "4":
                    {
                        return sum;
                    }
                    default:
                    {
                        Console.WriteLine("Please enter a valid choice");
                        break;
                    }
                }
                Console.WriteLine("Press 4 to stop purchasing");
            }
        }
    }
}
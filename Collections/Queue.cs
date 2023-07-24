using System;
using System.Collections;
using System.Collections.Generic;

namespace Q
{
    class Q
    {
        public static void Main()
        {
            Queue<string> queue = new Queue<string> ();
            //Enqueue()
            queue.Enqueue("Apple");
            queue.Enqueue("Orange");
            queue.Enqueue("Papaya");

            //Iterating through queue
            System.Console.WriteLine("\nPrinting queue contents: ");
            printQueue(queue);

            //Peek()
            System.Console.WriteLine("\nFirst element in queue: " + queue.Peek());

            //Dequeue()
            queue.Dequeue();
            System.Console.WriteLine("\nPrinting queue contents after dequeue: ");
            printQueue(queue);

            //GetHashCode()
            System.Console.WriteLine("\nGetHashCode(): " + queue.GetHashCode());

            //ToArray()
            Object[] qArray = queue.ToArray();
            System.Console.WriteLine("\nPrinting qArray contents: ");
            foreach(string i in qArray)
            {
                System.Console.WriteLine(i);
            }

            //Contains(T)
            System.Console.WriteLine("\nContains(\"Banana\"): " + qArray.Contains("Banana"));

            //CopyTo(T[], Int32)
            string[] myArray = new string[5];
            queue.CopyTo(myArray, 0);
            System.Console.WriteLine("\nPrinting myArray contents: ");
            for(int i=0; i < myArray.Length && myArray[i]!=null; i++)
            {
                System.Console.WriteLine(myArray[i]);
            }T

            //Clear()
            queue.Clear();
            System.Console.WriteLine("\nCount of queue after Clear(): " + queue.Count);
        }

        public static void printQueue(Queue<string> queue)
        {
            foreach(string q in queue)
            {
                Console.WriteLine(q);
            }
        }
    }
}

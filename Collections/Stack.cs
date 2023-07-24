using System;
using System.Collections;

namespace StackCollection
{
    class StackCollection
    {
        public static void Main()
        {
            Stack stk = new Stack();
            //Add()
            stk.Push(1001);
            stk.Push(1002);
            stk.Push(1003);
            stk.Push(1004);
            stk.Push(1007);

            //Iterating stack content
            System.Console.WriteLine("\nPrinting stack contents:");
            printStack(stk);

            //Contains(T)
            System.Console.WriteLine("Contains(1005): " + stk.Contains(1005));

            //Peek()
            System.Console.WriteLine("Top element in stack: " + stk.Peek());

            //Pop()
            stk.Pop();
            System.Console.WriteLine("\nPrinting stack after popping: ");
            printStack(stk);

            //GetHashCode()
            System.Console.WriteLine("HashCode of stack: " + stk.GetHashCode());

            //ToArray()
            Object[] array = stk.ToArray();
            System.Console.WriteLine("\nPrinting stack after converting into array: ");
            foreach(int i in array)
            {
                System.Console.WriteLine(i);    
            }

            //Clone() - On making changes in the new copy, it'll not reflect in the original copy
            Stack stk2 = (Stack)stk.Clone();
            stk2.Pop();
            System.Console.WriteLine("\nPrinting clone of stack: ");
            printStack(stk2);
            System.Console.WriteLine("\nPrinting original stack contents: ");
            printStack(stk);

            //Creating an array to demonstrate CopyTo(Array, Int32)
            int[] myArray = new int[10]{789, 754, 721, 0, 0, 0, 0, 0, 0, 0};
            stk.CopyTo(myArray, 3);

            //Printing myArray
            System.Console.WriteLine("\nPrinting myArray: ");
            foreach(int i in myArray)
            {
                Console.WriteLine(i);
            }

            //Clear()
            stk.Clear();
            System.Console.WriteLine("\nOn Clear(), the count is: " + stk.Count);
        }

        public static void printStack(Stack stk)
        {
            foreach(var stackElement in stk)
            {
                Console.WriteLine(stackElement);
            }
        }
    }
}

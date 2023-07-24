using System;
using System.Collections.Generic;

namespace LinkedListCollection
{
    class LinkedListCollection
    {
        public static void Main()
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            //AddFirst(), AddLast()
            linkedList.AddFirst("C#");
            linkedList.AddLast("Java");
            linkedList.AddFirst("C++");

            //Iterating through linkedlist
            System.Console.WriteLine("\nPrinting linked list contents: ");
            printLinkedList(linkedList);

            //AddAfter(LinkedListNode<T>, T), AddBefore(LinkedListNode<T>, T)
            var firstNode = linkedList.AddFirst("Go");
            linkedList.AddAfter(firstNode, "Pascal");
            linkedList.AddBefore(firstNode, "Python");

            //Iterating through linkedlist
            System.Console.WriteLine("\nPrinting linked list contents: ");
            printLinkedList(linkedList);

            //Contains(T)
            Console.WriteLine("\nContains(\"Java\"): " + linkedList.Contains("Java"));

            //GetHashCode()
            System.Console.WriteLine("\nGetHashCode: " + linkedList.GetHashCode());

            LinkedList<string> linkedList2 = new LinkedList<string>();
            linkedList2.AddFirst("Python");
            linkedList2.AddLast("Go");
            linkedList2.AddLast("Pascal");
            linkedList2.AddLast("C++");
            linkedList2.AddLast("C#");
            linkedList2.AddLast("Java");
            //Iterating through linkedlist2
            System.Console.WriteLine("\nPrinting linked list 2 contents: ");
            printLinkedList(linkedList2);

            //Equals(Object)
            System.Console.WriteLine("\nlinkedList.Equals(linkedList2): " + linkedList.Equals(linkedList2));

            LinkedList<string> linkedList3 = linkedList2;
            System.Console.WriteLine("linkedList3.Equals(linkedList2): " + linkedList3.Equals(linkedList2));

            //First property
            System.Console.WriteLine("\nFirst of linkedlist: " + linkedList.First.Value);

            //Last property
            System.Console.WriteLine("\nLast of linkedList: " + linkedList.Last.Value);

            //Count property
            System.Console.WriteLine("\nCount of linkedList: " + linkedList.Count);

            //Find(T)
            System.Console.WriteLine("\nFind(\"Go\"): " + linkedList.Find("Go").Value);

            linkedList.AddLast("C#");
            //FindLast(T)
            System.Console.WriteLine("\nFindLast(\"C#\"): " + linkedList.FindLast("C#").Value);

            //Remove(T)
            linkedList.Remove("C#");
            System.Console.WriteLine("\nPrinting linkedlist contents after Remove(\"C#\"):");
            printLinkedList(linkedList);

            //RemoveFirst(T)
            linkedList.RemoveFirst();

            //RemoveLast(T)
            linkedList.RemoveLast();

            //ToArray()
            Object[] myArray = linkedList.ToArray();
            System.Console.WriteLine("\nPrinting myArray contents: ");
            foreach(string i in myArray)
            {
                System.Console.WriteLine(i);
            }
        }

        public static void printLinkedList(LinkedList<string> linkedList)
        {
            foreach(string i in linkedList)
            {
                Console.WriteLine(i);
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace Demo
{
    class SortedList
    {
        public static void Main()
        {
            SortedList<int, string> sortedList = new SortedList<int, string>();
            //Add(TKey, TValue)
            sortedList.Add(7, "MS Dhoni");
            sortedList.Add(10, "Sachin");
            sortedList.Add(18, "Virat");
            sortedList.Add(3, "Suresh Raina");
            sortedList.Add(19, "Dinesh Karthik");

            //Iterating thorugh the sortedList
            System.Console.WriteLine("Printing sortedList contents: ");
            printSortedList(sortedList);

            //Capacity property
            System.Console.WriteLine("\nsortedList.Capacity: {0}", sortedList.Capacity);

            //Count property
            System.Console.WriteLine("\nsortedList.Count: {0}", sortedList.Count);

            //ContainsKey(Object)
            System.Console.WriteLine("\nsortedList.ContainsKey(7): {0}", sortedList.ContainsKey(7));

            //ContainsValue(Object)
            System.Console.WriteLine("\nsortedList.ContainsValue(\"Suresh Raina\"): {0}", sortedList.ContainsValue("Suresh Raina"));

            //IndexOfKey(Object)
            System.Console.WriteLine("\nsortedList.IndexOfKey(19): {0}", sortedList.IndexOfKey(19));

            //IndexOfValue(Object)
            System.Console.WriteLine("\nsortedList.IndexOfValue(\"Sachin\"): {0}", sortedList.IndexOfValue("Sachin"));

            //Remove(Object)
            sortedList.Remove(1);

            //RemoveAt(Int32)
            sortedList.RemoveAt(2);

            System.Console.WriteLine("\nPrinting sortedList contents after removing: ");
            printSortedList(sortedList);

        }

        public static void printSortedList(SortedList<int, string> sortedList)
        {
            IDictionaryEnumerator collection = (IDictionaryEnumerator)sortedList.GetEnumerator();
            while(collection.MoveNext())
            {
                System.Console.WriteLine(collection.Key + " " + collection.Value);
            }
        } 
    }
}

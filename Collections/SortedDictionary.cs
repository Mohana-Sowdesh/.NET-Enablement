using System;
using System.Collections.Generic;

namespace Demo
{
    class SortedDictionaryCollection
    {
        public static void Main(string[] args)
        {
            SortedDictionary<int,string> sortedDictionary = new SortedDictionary<int,string>();
            //Add(TKey, TValue)
            sortedDictionary.Add(7, "MS Dhoni");
            sortedDictionary.Add(10, "Sachin");
            sortedDictionary.Add(18, "Virat");
            sortedDictionary.Add(3, "Suresh Raina");
            sortedDictionary.Add(19, "Dinesh Karthik");

            //Iterating through sortedDictionary contents
            System.Console.WriteLine("\nPrinting sortedDictionary contents: ");
            printSortedDictionary(sortedDictionary);

            //ContainsKey(TKey)
            System.Console.WriteLine("\nsortedDictionary.ContainsKey(3): " + sortedDictionary.ContainsKey(3));

            //ContainsValue(TValue) 
            System.Console.WriteLine("\nsortedDictionary.ContainsValue(\"MS Dhoni\"): " + sortedDictionary.ContainsValue("MS Dhoni"));

            //GetHashCode()
            System.Console.WriteLine("\nGetHashCode(): " + sortedDictionary.GetHashCode());

            //Remove(TKey)
            sortedDictionary.Remove(18);

            System.Console.WriteLine("\nPrinting sortedDictionary contents after removing: ");
            printSortedDictionary(sortedDictionary);	

            //TryGetValue(TKey, TValue)
            string value = "";
            sortedDictionary.TryGetValue(7, out value);
            System.Console.WriteLine("\nsortedDictionary.TryGetValue(7, out value): {0}", value);

            //Clear()
            sortedDictionary.Clear();
            System.Console.WriteLine("\nsortedDictionary.Count after Clear(): {0}", sortedDictionary.Count);
        }

        public static void printSortedDictionary(SortedDictionary<int, string> sortedDictionary)
        {
            foreach (KeyValuePair<int,string> keyValuePair in sortedDictionary)
            {
                System.Console.WriteLine(keyValuePair.Key+ " " + keyValuePair.Value);
            }
        } 
    }
}

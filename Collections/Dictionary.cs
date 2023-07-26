using System;
using System.Collections.Generic;

namespace Demo
{
    class DictionaryCollection
    {
        public static void Main(string[] args)
        {
            Dictionary<int,string> dictionary = new Dictionary<int,string>();
            //Add(TKey, TValue)
            dictionary.Add(7, "MS Dhoni");
            dictionary.Add(10, "Sachin");
            dictionary.Add(18, "Virat");
            dictionary.Add(3, "Suresh Raina");
            dictionary.Add(19, "Dinesh Karthik");

            //Iterating through dictionary contents
            System.Console.WriteLine("\nPrinting dictionary contents: ");
            printDictionary(dictionary);

            //ContainsKey(TKey)
            System.Console.WriteLine("\ndictionary.ContainsKey(3): " + dictionary.ContainsKey(3));

            //ContainsValue(TValue) 
            System.Console.WriteLine("\ndictionary.ContainsValue(\"MS Dhoni\"): " + dictionary.ContainsValue("MS Dhoni"));

            //GetHashCode()
            System.Console.WriteLine("\nGetHashCode(): " + dictionary.GetHashCode());

            //Remove(TKey)
            dictionary.Remove(18);

            System.Console.WriteLine("\nPrinting dictionary contents after removing: ");
            printDictionary(dictionary);

            //TryAdd(TKey, TValue)	
            dictionary.TryAdd(73, "Umesh");

            System.Console.WriteLine("\nPrinting dictionary contents after TryAdd(): ");
            printDictionary(dictionary);	

            //TryGetValue(TKey, TValue)
            string value = "";
            dictionary.TryGetValue(7, out value);
            System.Console.WriteLine("\ndictionary.TryGetValue(7, out value): {0}", value);

            //Clear()
            dictionary.Clear();
            System.Console.WriteLine("\ndictionary.Count after Clear(): {0}", dictionary.Count);
        }

        public static void printDictionary(Dictionary<int, string> dictionary)
        {
            foreach (KeyValuePair<int,string> keyValuePair in dictionary)
            {
                System.Console.WriteLine(keyValuePair.Key+ " " + keyValuePair.Value);
            }
        } 
    }
}

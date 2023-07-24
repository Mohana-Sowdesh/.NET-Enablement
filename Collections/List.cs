using System;
using System.Collections.Generic;

namespace Collections
{
    class ListCollection
    {
        public static void Main()
        {
            List<string> languages = new List<string> ();
            //Add()
            languages.Add("Tamil");
            languages.Add("Telugu");
            languages.Add("Kannada");
            languages.Add("Malayalam");
            languages.Add("Konkani");

            //Iterating list using foreach loop
            Console.WriteLine("Printing contents of 'language' list:");
            printList(languages);

            //Count property
            System.Console.WriteLine("\nCount of language list: " + languages.Count);

            //Capacity property
            System.Console.WriteLine("\nCapacity of language list: " + languages.Capacity);

            //BinarySearch()
            System.Console.WriteLine("\nIndex of 'Tamil': " + languages.BinarySearch("Tamil"));

            //Sort()
            languages.Sort();
            Console.WriteLine("\nPrinting contents of 'language' list after sorting:");
            printList(languages);

            //BinarySearch()
            System.Console.WriteLine("\nIndex of 'Tamil': " + languages.BinarySearch("Tamil"));

            //Contains(T)
            System.Console.WriteLine("\nDoes list contains 'Hindi': " + languages.Contains("Hindi"));

            //IndexOf(T)
            System.Console.WriteLine("\nIndex of 'Malayalam': " + languages.IndexOf("Malayalam"));

            //ToArray()
            var lang = languages.ToArray();
            //Printing lang array
            System.Console.WriteLine("\nPrinting lang array:");
            foreach(string language in lang)
            {
                System.Console.WriteLine(language);
            }

            //Insert(Int32, T)
            languages.Insert(2, "Assamese");

            //Remove(T)
            languages.Remove("Hindi");
            Console.WriteLine("\nPrinting contents of 'language' list after removing 'Hindi':");
            printList(languages);

            //LastIndexOf(T)
            languages.Add("Tamil");
            System.Console.WriteLine("\nLast index of 'Tamil': " + languages.LastIndexOf("Tamil"));

            //Reverse()
            languages.Reverse();
            Console.WriteLine("\nPrinting contents of 'language' list after reversing:");
            printList(languages);

            //TrimExcess()
            System.Console.WriteLine("\nBefore trimming - Capacity of language list: " + languages.Capacity);
            System.Console.WriteLine("Before trimming - Count of language list: " + languages.Count);
            languages.TrimExcess();
            System.Console.WriteLine("\nAfter trimming - Capacity of language list: " + languages.Capacity);
            System.Console.WriteLine("After trimming - Count of language list: " + languages.Count);

            //Clear()
            languages.Clear();
            System.Console.WriteLine("\nCount of language lsit after clearing: " + languages.Count);
        }

        public static void printList(List<string> list)
        {
            foreach(string language in list)
            {
                Console.WriteLine(language);
            }
        }
    }
}

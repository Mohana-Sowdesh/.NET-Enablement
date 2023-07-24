using System;
using System.Collections.Generic;

namespace HashSetCollection
{
    class HashSetCollection
    {
        public static void Main()
        {
            HashSet<string> hashSet = new HashSet<string>();
            //Add(T)
            hashSet.Add("India");
            hashSet.Add("Germany");
            hashSet.Add("Brazil");

            //Iterating through the hashset
            System.Console.WriteLine("\nPrinting hashSet contents: ");
            printHashSet(hashSet);

            //Contains(T)
            System.Console.WriteLine("\nContains(\"Brazil\"): " + hashSet.Contains("Brazil"));

            //GetHashCode()
            System.Console.WriteLine("\nGetHashCode(): " + hashSet.GetHashCode());

            //Count property
            System.Console.WriteLine("\nCount of hashSet: " + hashSet.Count);

            HashSet<string> hashSet2 = new HashSet<string>();
            hashSet2.Add("India");
            hashSet2.Add("Germany");
            hashSet2.Add("Brazil");
            //Equals(Object)
            System.Console.WriteLine("\nhashSet2.Equals(hashSet): " + hashSet2.Equals(hashSet));

            HashSet<string> hashSet3 = hashSet2;
            System.Console.WriteLine("\nhashSet3.Equals(hashSet2): " + hashSet3.Equals(hashSet2));

            //Remove(T)
            hashSet.Remove("Brazil");

            //CopyTo(T[], Int32)
            string[] myArray = new string[5];
            hashSet.CopyTo(myArray, 0);
            System.Console.WriteLine("\nPrinting myArray contents: ");
            foreach(string i in myArray)
            {
                Console.WriteLine(i);
            }  

            hashSet2.Add("Morocco");
            hashSet2.Add("Canada");
            hashSet.Add("Malaysia");

            System.Console.WriteLine("\nPrinting hashSet contents before union: ");
            printHashSet(hashSet);

            System.Console.WriteLine("\nPrinting hashSet2 contents before union: ");
            printHashSet(hashSet2);
            //Set operations - UnionWith()
            hashSet.UnionWith(hashSet2);
            System.Console.WriteLine("\nPrinting hashSet contents after union: ");
            printHashSet(hashSet);

            hashSet3.Remove("Canada");
            hashSet3.Remove("Morocco");
            hashSet3.Add("Ukraine");

            System.Console.WriteLine("\nPrinting hashSet3 contents before union: ");
            printHashSet(hashSet3);
            //Set operations - IntersectWith(IEnumerable<T>)
            hashSet.IntersectWith(hashSet3);
            System.Console.WriteLine("\nPrinting hashSet contents after intersection: ");
            printHashSet(hashSet);

            //Overlaps(IEnumerable<T>) - determines if both collections share common elements
            System.Console.WriteLine("\nhashSet3.Overlaps(hashSet): "  + hashSet3.Overlaps(hashSet));
            System.Console.WriteLine("hashSet2.Overlaps(hashSet3): "  + hashSet2.Overlaps(hashSet3));

            //IsProperSubsetOf(IEnumerable<T>)
            System.Console.WriteLine("\nhashSet2.IsProperSubsetOf(hashSet): " + hashSet2.IsProperSubsetOf(hashSet));
            System.Console.WriteLine("hashSet.IsProperSubsetOf(hashSet2): " + hashSet.IsProperSubsetOf(hashSet2));

            //IsProperSupersetOf(IEnumerable<T>)
            System.Console.WriteLine("\nhashSet.IsProperSupersetOf(hashSet2): " + hashSet.IsProperSupersetOf(hashSet2));
            System.Console.WriteLine("hashSet2.IsProperSupersetOf(hashSet): " + hashSet2.IsProperSupersetOf(hashSet));

            //IsSubset(IEnumerable<T>)
            System.Console.WriteLine("\nhashSet.IsSubsetOf(hashSet2): " + hashSet.IsSubsetOf(hashSet2));
            System.Console.WriteLine("hashSet2.IsSubsetOf(hashSet): " + hashSet2.IsSubsetOf(hashSet));

            //IsSuperset(IEnumerable<T>)
            System.Console.WriteLine("\nhashSet.IsSupersetOf(hashSet2): " + hashSet.IsSupersetOf(hashSet2));
            System.Console.WriteLine("hashSet2.IsSupersetOf(hashSet): " + hashSet2.IsSupersetOf(hashSet));
        }

        public static void printHashSet(HashSet<string> hashSet)
        {
            foreach(string h in hashSet)
            {
                Console.WriteLine(h);
            }
        }
    }
}

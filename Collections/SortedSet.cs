using System;
using System.Collections.Generic;

namespace Demo
{
    class SortedSetCollection
    {
        public static void Main(string[] args)
        {
            SortedSet<int> sortedSet = new SortedSet<int>();
            //Add(T)
            sortedSet.Add(77329);
            sortedSet.Add(25656);
            sortedSet.Add(376);
            sortedSet.Add(2255);
            sortedSet.Add(77329);

            //Iterating through sortedSet
            System.Console.WriteLine("Printing sortedSet contents: ");
            printSortedSet(sortedSet);

            //Count
            System.Console.WriteLine("\nsortedSet.Count: " + sortedSet.Count);

            //Max
            System.Console.WriteLine("\nsortedSet.Max: " + sortedSet.Max);

            //Min
            System.Console.WriteLine("\nsortedSet.Min: " + sortedSet.Min);

            //Contains(T)
            System.Console.WriteLine("\nsortedSet.Contains(376): " + sortedSet.Contains(376));

            //GethashCode()
            System.Console.WriteLine("\nsortedSet.GetHashCode(): " + sortedSet.GetHashCode());

            //Remove()
            sortedSet.Remove(25656);
            System.Console.WriteLine("\nPrinting sortedSet contents after removing: ");
            printSortedSet(sortedSet);

            SortedSet<int> sortedSet2 = new SortedSet<int>();
            sortedSet2.Add(77329);
            sortedSet2.Add(25656);
            sortedSet2.Add(376);
            sortedSet2.Add(2255);
            sortedSet2.Add(89425);

            //Overlaps(IEnumerable<T>)
            System.Console.WriteLine("\nsortedSet.Overlaps(sortedSet2): " + sortedSet.Overlaps(sortedSet2));

            //IsProperSubsetOf(IEnumerable<T>)
            System.Console.WriteLine("\nsortedSet.IsProperSubsetOf(sortedSet2): " + sortedSet.IsProperSubsetOf(sortedSet2));
            System.Console.WriteLine("sortedSet2.IsProperSubsetOf(sortedSet2): " + sortedSet2.IsProperSubsetOf(sortedSet));

            //IsProperSupersetOf(IEnumerable<T>)
            System.Console.WriteLine("\nsortedSet.IsProperSupersetOf(sortedSet2): " + sortedSet.IsProperSupersetOf(sortedSet2));
            System.Console.WriteLine("sortedSet2.IsProperSupersetOf(sortedSet): " + sortedSet2.IsProperSupersetOf(sortedSet));

            //UnionWith(IEnumerable<T>)
            sortedSet.UnionWith(sortedSet2);
            System.Console.WriteLine("\nPrinting sortedSet after union with sortedSet2: ");
            printSortedSet(sortedSet);

            //IsSubsetOf(IEnumerable<T>)
            System.Console.WriteLine("\nsortedSet.IsSubsetOf(sortedSet2): " + sortedSet.IsSubsetOf(sortedSet2));
            System.Console.WriteLine("sortedSet2.IsSubsetOf(sortedSet): " + sortedSet2.IsSubsetOf(sortedSet));

            //IsSupersetOf(IEnumerable<T>)
            System.Console.WriteLine("\nsortedSet.IsSupersetOf(sortedSet2): " + sortedSet.IsSupersetOf(sortedSet2));
            System.Console.WriteLine("sortedSet2.IsSupersetOf(sortedSet): " + sortedSet2.IsSupersetOf(sortedSet));

            //CopyTo(T[])
            int[] myArray = new int[5];
            sortedSet.CopyTo(myArray, 0);
            System.Console.WriteLine("\nPrinting myArray contents: ");
            foreach(int i in myArray)
            {
                System.Console.WriteLine(i);
            }

            //TryGetValue(T, T)
            int v = -1;
            System.Console.WriteLine("\nsortedSet.TryGetValue(7887, out v): " + sortedSet.TryGetValue(7887,out v));

            //Equals(Object)
            System.Console.WriteLine("\nPrinting sortedSet contents: ");
            printSortedSet(sortedSet);

            System.Console.WriteLine("\nPrinting sortedSet2 contents: ");
            printSortedSet(sortedSet2);

            System.Console.WriteLine("\nsortedSet.Equals(sortedSet2): " + sortedSet.Equals(sortedSet2));
            SortedSet<int> sortedSet3 = sortedSet2;
            System.Console.WriteLine("sortedSet2.Equals(sortedSet3): " + sortedSet2.Equals(sortedSet3));

            //Clear()
            sortedSet.Clear();
            System.Console.WriteLine("\nsortedSet.Count after Clear(): " + sortedSet.Count);
        }

        public static void printSortedSet(SortedSet<int> sortedSet)
        {
            foreach(int i in sortedSet)
            {
                Console.WriteLine(i);
            }
        }
    }
}

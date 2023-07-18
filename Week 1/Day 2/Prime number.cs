/*

2. Write a program to print all the Prime Numbers within a given Range 

Input: 1 10
Output: 2 3 5 7 

*/

using System;
class PrimeNumber {
  static void Main() {
    Console.WriteLine("Enter the starting number to find the prime numbers lying in the range: ");
    int start = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("Enter the ending number: ");
    int end = Convert.ToInt32(Console.ReadLine());
    
    for(int i=start; i<end; i++) 
    {
        if(isPrime(i))
            Console.Write(i + " ");
    }
  }

  static bool isPrime(int n)
  {
    if (n <= 1)
        return false;
    else if (n == 2)
        return true;
    else if (n % 2 == 0)
        return false;
    for (int i = 3; i <= Math.Sqrt(n); i += 2) 
    {
        if (n % i == 0)
            return false;
    }
    return true;
  }
}

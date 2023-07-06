/*

2. Write a program to print all the Prime Numbers within a given Range 

Input: 1 10
Output: 2 3 5 7 

*/

using System;
class HelloWorld {
  static void Main() {
    Console.WriteLine("Enter the starting number to find the prime numbers lying in the range: ");
    int start = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("Enter the ending number: ");
    int end = Convert.ToInt32(Console.ReadLine());
    
    int i=0,j=0;
    bool flag=true;
    
    for(i=start; i<end; i++)
    {
        flag=true;
        
        if(i==0 || i==1)
            continue;
        
        for(j=2; j<=i/2; j++)
        {
            if(i%j==0) {
                flag = false;
                break;
            }
        }
        
        if(flag==true)
            Console.Write(i+" ");
    }
  }
}

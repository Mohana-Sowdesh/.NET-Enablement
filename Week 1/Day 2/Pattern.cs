/*

Print the following Pattern

Input: 5

Output:
    *
   ***
  *****
 *******
*********

*/
using System;
class HelloWorld {
  static void Main() {
    Console.WriteLine("Please enter the number of lines: ");
    int lines = Convert.ToInt32(Console.ReadLine());
    int i=0,j=0,k=0;
    
    for(i=1; i<=lines; i++)
    {
        for(j=1; j<=lines-i; j++)
        {
            Console.Write(" ");
        }
        for(k=1; k<=(2*i)-1; k++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }
  }
}

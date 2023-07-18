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
    
    for(int i=0; i<lines; i++)
    {
        int j = 0;
        for(j=0; j<lines-i-1; j++)
        {
            Console.Write(" ");
        }
        for(j=0; j<(2*i)+1; j++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }
  }
}

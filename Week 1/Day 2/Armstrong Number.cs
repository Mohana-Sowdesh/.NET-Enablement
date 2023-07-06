/*

1. Write a C# program to find if a given number is Armstrong number or Not 
Input : 153
Output : Armstrong

Input: 57
Output: Not an Armstrong Number

Note: A number is considered as an Armstrong number if the sum of its own digits raised to the power number of digits gives the number itself. 
For example: 0, 1, 153, 370, 371, 407, 1634, 8208, 9474 are Armstrong numbers

*/

using System;
class HelloWorld {
  static void Main() {
    Console.WriteLine("Please enter a number: ");
    int num = Convert.ToInt32(Console.ReadLine());
    int temp = num;
    int original_num = num;
    int i = 0,sum = 0;
    
    while(num > 0) 
    {
        num /= 10;
        i++;
    }
    
    while(temp > 0)
    {
        int t = temp%10;
        sum += Convert.ToInt32(Math.Pow(t, i));
        temp = temp/10;
    }
    
    if(sum==original_num)
    {
        Console.WriteLine(original_num + " is an Armstrong number");
    }
    else
    {
         Console.WriteLine(original_num + " is not an Armstrong number");
    }
  }
}

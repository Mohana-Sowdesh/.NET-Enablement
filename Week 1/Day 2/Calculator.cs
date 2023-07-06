/*

Write a program using switch case to create a Calculator [add,sub,mul,div,modulus]

Input: add 5 10
Output: 15

Input: multiply 2 7
Output: 14


*/

using System;
class HelloWorld {
  static void Main(string[] args) {
    Console.WriteLine("1.Add 2.Subtract 3.Multiply 4.Divide 5.Modulus");
    Console.WriteLine("Please enter an operation to perform: ");
    string operation = Console.ReadLine();
    
    Console.WriteLine("Enter the first number: ");
    int a = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("Enter the second number: ");
    int b = Convert.ToInt32(Console.ReadLine());
    
    int res =0;
    
    switch(operation){
        case "add":
            res = a+b;
            break;
        case "subtract":
            res = a-b;
            break;
        case "multiply":
            res = a*b;
            break;
        case "divide":
            res = a/b;
            break;
        case "modulus":
            res = a%b;
            break;   
        default:
            Console.WriteLine("Please enter a valid oper");
            break;
    }
    
    Console.WriteLine("The result is " + res);
  }
}

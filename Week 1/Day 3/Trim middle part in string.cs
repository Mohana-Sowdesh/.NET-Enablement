using System;
class HelloWorld {
  static void Main() {
    Console.WriteLine("Enter a string: ");
    string str = Console.ReadLine();
    
    Console.WriteLine("Enter the no. of characters to be trimmed from the start and end: ");
    int trim_number = Convert.ToInt32(Console.ReadLine());
    
    string result;
    if(str.Length > trim_number*2){
        result = str.Substring(0, trim_number) + str.Substring(str.Length - trim_number);
        Console.WriteLine(result);
    }
    else {
        Console.WriteLine("The no. of characters to be trimmed from the start and end must be greater than string length");
    }
  }
}

using System;
class HelloWorld {
  static void Main() {
    Console.WriteLine("Enter a string: ");
    string str = Console.ReadLine();
    
    Console.WriteLine("Enter the no. of characters to be trimmed from the start and end: ");
    int trimNumber = Convert.ToInt32(Console.ReadLine());
    
    if(str.Length > trimNumber*2){
        for(int i=0; i<trimNumber; i++)
        {
            Console.Write(str[i]);
        }
        for(int i=str.Length-trimNumber; i<str.Length; i++)
        {
            Console.Write(str[i]);
        }
    }
    else {
        Console.WriteLine("The no. of characters to be trimmed from the start and end must be greater than string length");
    }
  }
}

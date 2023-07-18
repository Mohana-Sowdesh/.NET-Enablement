using System;

class HelloWorld {
  static int CalcProduct(int number) {
    int product = 1;
    while(number > 0) {
        int temp = number % 10;
        number = number / 10;
        product = product * temp;
    }
    if(product >= 10)
        CalcProduct(product);
    return product;
  }
  
  static void Main() {
    Console.WriteLine("Enter a number: ");
    int num = Convert.ToInt32(Console.ReadLine());
    int result = CalcProduct(num);
    Console.WriteLine(result);
  }
}

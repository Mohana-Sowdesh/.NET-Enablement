using System;
using System.Text;

class HelloWorld {
  static void Main() {
    Console.WriteLine("Enter the string: ");
    string str = Console.ReadLine();
    StringBuilder characters = new StringBuilder();
    int number = 0;
    StringBuilder sb = new StringBuilder();
    
    for(int i=0; i<str.Length; i++) {
        if(Char.IsLetter(str[i])) {
            characters.Append(str[i]);
        }
        else {
            number = number*10 + Convert.ToInt32(str[i].ToString());
            if(i+1==str.Length || Char.IsLetter(str[i+1])) {
                string str_temp = appendChars(number, characters.ToString());
                sb.Append(str_temp); 
                number = 0;
                characters.Clear();
            }
        }
    }
    Console.WriteLine(sb.ToString());
  }
  
  static string appendChars(int number, string character) {
    StringBuilder sb = new StringBuilder();
    for(int i=0; i<number; i++) {
        sb.Append(character);
    }
    return sb.ToString();
  }
}

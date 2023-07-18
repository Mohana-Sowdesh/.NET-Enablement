/*

Write a program to print the following String pattern 
Input: a3b10c4
Output: aaabbbbbbbbbbcccc

*/

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
        if((Convert.ToInt32(str[i]) >= 97 && Convert.ToInt32(str[i]) <= 122) || (Convert.ToInt32(str[i]) >= 65 && Convert.ToInt32(str[i]) <= 90)) {
            characters.Append(str[i]);
        }
        else {
            number = number*10 + Convert.ToInt32(str[i].ToString());
            if(i+1==str.Length || (Convert.ToInt32(str[i+1]) < 48 || Convert.ToInt32(str[i+1]) > 57))
            {
                string strTemp = AppendChars(number, characters.ToString());
                sb.Append(strTemp); 
                number = 0;
                characters.Clear();
            }
        }
    }
    Console.WriteLine(sb.ToString());
  }
  
  static string AppendChars(int number, string character) {
    StringBuilder sb = new StringBuilder();
    for(int i=0; i<number; i++) {
        sb.Append(character);
    }
    return sb.ToString();
  }
}

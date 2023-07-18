using System;
using System.Text;

class Encryption {
    static void Main() {
        Console.WriteLine("Enter the no. of characters: ");
        int usrInput = Convert.ToInt32(Console.ReadLine());
        StringBuilder stringBuilder = new StringBuilder();

        for( ; usrInput!=0; ) {
            char character = char.Parse(Console.ReadLine());
            int ascii = (int)(character);
            int firstDigit = 0, temp = ascii, rem = 0;
            for( ; temp != 0; ) {
                rem = temp % 10;
                temp = temp / 10;
            }
            firstDigit = rem;
            int lastDigit = ascii % 10;

            int firstPart = ascii + lastDigit;
            string middlePart = (firstDigit * 10 + lastDigit).ToString();
            int lastPart = ascii - firstDigit;

            stringBuilder.Append((char)firstPart + middlePart + (char)lastPart);
            usrInput--;
        }
        Console.WriteLine(stringBuilder.ToString());
    }
}

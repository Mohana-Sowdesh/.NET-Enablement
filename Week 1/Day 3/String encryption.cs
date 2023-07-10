using System;

class Encryption {
    static void Main() {
        Console.WriteLine("Enter the no. of characters: ");
        int usr_input = Convert.ToInt32(Console.ReadLine());
        StringBuilder stringBuilder = new StringBuilder();

        while(usr_input!=0) {
            char character = char.Parse(Console.ReadLine());
            int ascii = charToInt(character);
            int first_digit = 0, temp = ascii, rem = 0;
            while(temp!=0) {
                rem = temp%10;
                temp = temp/10;
            }
            first_digit = rem;
            int last_digit = ascii%10;

            int first_part = ascii+last_digit;
            string middle_part = first_digit.ToString()+last_digit.ToString();
            int last_part = ascii-first_digit;

            stringBuilder.Append((char)first_part + middle_part + (char)last_part);
            usr_input--;
        }
        Console.WriteLine(stringBuilder.ToString());
    }

    static int charToInt(char character) {
        return (int)character;
    } 
}

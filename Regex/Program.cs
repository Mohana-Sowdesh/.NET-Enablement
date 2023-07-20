using System.Text.RegularExpressions;

namespace RegExp
{
    class RegExp
    {
        static void Main()
        {
            string pattern = "Sam";
            Console.WriteLine(Regex.IsMatch("Samuel", pattern)); //true
            Console.WriteLine(Regex.IsMatch("samuel", pattern)); //false
            //Because Regex.IsMatch() is case sensitive
            Console.WriteLine(Regex.IsMatch("samuel", pattern, RegexOptions.IgnoreCase)); //true

            pattern = "[Ss]am";
            Console.WriteLine(Regex.IsMatch("samuel", pattern)); //true

            pattern = "^Sam";
            Console.WriteLine(Regex.IsMatch("Samuel is playing", pattern)); //true
            Console.WriteLine(Regex.IsMatch("Sanjari and Samuel are playing", pattern)); //false

            pattern = @"(\s|^)Sam(\s|$)";
            Console.WriteLine(Regex.IsMatch("Sanjari and Sam", pattern)); //true

            pattern = @"\(?\d{3}\)?(-|.|\s)?\d{3}(-|.)?\d{4}";
            Console.WriteLine("\n" + Regex.IsMatch("444 443 0985", pattern)); //true
            Console.WriteLine(Regex.IsMatch("(444) 442 555", pattern)); //false
            Console.WriteLine(Regex.IsMatch("442-894-6888", pattern)); //true
            Console.WriteLine(Regex.IsMatch("123.123.4445", pattern)); //true
        }
    }
}
s

using System;

namespace ExceptionHandling
{
    class ExceptionHandling
    {
        static void Main()
        {
            int a = 67, b = 0;
            try
            {
                int result = divide(a,b);
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int divide(int a, int b)
        {
            return a/b;
        }
    }
}

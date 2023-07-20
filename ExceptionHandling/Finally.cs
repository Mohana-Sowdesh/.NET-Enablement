using System;

namespace ExceptionHandling
{
    class ExceptionHandling
    {
        static void Main()
        {
            Demo demo = new Demo();
            try
            {
                int result = demo.GrandparentMethod(5);
                Console.WriteLine($"The value of result is {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("In finally block...");
            }
        }
    }

    class Demo 
    {
        public int GrandparentMethod(int position)
        {
            return ParentMethod(position);
        }

        public int ParentMethod(int position)
        {
            return GetNumber(position);
        }

        public int GetNumber(int position)
        {
            int[] numbers = new int[]{1, 4, 6, 9};
            return numbers[position];
        }
    }
}

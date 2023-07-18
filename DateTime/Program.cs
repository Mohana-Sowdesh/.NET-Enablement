using System;

namespace DateTimeLearning
{
    class DateTimeLearning
    {
        static void Main()
        {
            //Default DateTime
            System.DateTime s6 = new DateTime();
            System.Console.WriteLine("Default DateTime: " + s6);

            //Coordinated Universal Time
            System.Console.WriteLine("UTC DateTime: " + DateTime.UtcNow);

            System.Console.WriteLine("DateTime MaxValue: " + DateTime.MaxValue);

            DateTime s2 = DateTime.Today;
            System.Console.WriteLine("Today DateTime: " + s2);

            System.Console.WriteLine("Today's day: " + DateTime.Now.DayOfWeek);

            DateTime s1 = DateTime.Now;
            DateTime s7 = DateTime.UtcNow;
            System.Console.WriteLine(s1.Kind);
            System.Console.WriteLine(s7.Kind);
            System.Console.WriteLine("Now: " + s1);
            System.Console.WriteLine("Adding hours: " + s1.AddHours(3));
            System.Console.WriteLine("Subtracting hours: " + s1.AddHours(-3));

            TimeSpan timeSpan = TimeSpan.Parse("5:4:15:13.123");
            Console.WriteLine(s1.Add(timeSpan));

        }   
    }
}

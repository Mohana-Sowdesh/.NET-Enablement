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

            //DateTime Conversion from one timezone to another time zone
            //1st method -  ConvertTime(DateTime, TimeZoneInfo)
            //public static DateTime ConvertTime (DateTime dateTime, TimeZoneInfo destinationTimeZone);
            //Eg 1
            Console.WriteLine("\n\n\nTime Zone conversions - Method 1");
            DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")); 
            //This converts the local time zone current time to US Central Standard Time
            Console.WriteLine(currentTime);

            //Eg 2
            DateTime[] times = { new DateTime(2010, 1, 1, 0, 1, 0), 
                           new DateTime(2010, 1, 1, 0, 1, 0, DateTimeKind.Utc), 
                           new DateTime(2010, 1, 1, 0, 1, 0, DateTimeKind.Local),                            
                           new DateTime(2010, 11, 6, 23, 30, 0),
                           new DateTime(2010, 11, 7, 2, 30, 0) };
                              
            // Retrieve the time zone for Eastern Standard Time (U.S. and Canada).
            TimeZoneInfo est; 
            try {
                est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            }
            catch (TimeZoneNotFoundException) {
                Console.WriteLine("Unable to retrieve the Eastern Standard time zone.");
                return;
            }
            catch (InvalidTimeZoneException) {
                Console.WriteLine("Unable to retrieve the Eastern Standard time zone.");
                return;
            }   

            // Display the current time zone name.
            Console.WriteLine("Local time zone: {0}\n", TimeZoneInfo.Local.DisplayName);
            
            // Convert each time in the array.
            foreach (DateTime timeToConvert in times)
            {
                DateTime targetTime = TimeZoneInfo.ConvertTime(timeToConvert, est);
                Console.WriteLine("Converted {0} {1} to {2}.", timeToConvert, 
                                timeToConvert.Kind, targetTime);
            }   

            //2nd method -  ConvertTime(DateTimeOffset, TimeZoneInfo)
            //public static DateTimeOffset ConvertTime (DateTimeOffset dateTimeOffset, TimeZoneInfo destinationTimeZone);
            Console.WriteLine("\n\n\nTime Zone conversions - Method 2");
            DateTime time1 = new DateTime(2010, 1, 1, 12, 1, 0);
            DateTime time2 = new DateTime(2010, 11, 6, 23, 30, 0);
            DateTimeOffset[] times1 = { new DateTimeOffset(time1, TimeZoneInfo.Local.GetUtcOffset(time1)),
                                        new DateTimeOffset(time1, TimeSpan.Zero),
                                        new DateTimeOffset(time2, TimeZoneInfo.Local.GetUtcOffset(time2)),
                                        new DateTimeOffset(time2.AddHours(3), TimeZoneInfo.Local.GetUtcOffset(time2.AddHours(3))) };

            // Display the current time zone name.
            Console.WriteLine("Local time zone: {0}\n", TimeZoneInfo.Local.DisplayName);
            
            // Convert each time in the array.
            foreach (DateTimeOffset timeToConvert in times1)
            {
                DateTimeOffset targetTime = TimeZoneInfo.ConvertTime(timeToConvert, est);
                Console.WriteLine("Converted {0} to {1}.", timeToConvert, targetTime);
            }       

            //3rd method -  ConvertTime(DateTime, TimeZoneInfo, TimeZoneInfo)
            //public static DateTime ConvertTime (DateTime dateTime, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone);
            Console.WriteLine("\n\n\nTime Zone conversions - Method 3");
            DateTime hwTime = new DateTime(2007, 02, 01, 08, 00, 00);
            try
            {
                TimeZoneInfo hwZone = TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time");
                Console.WriteLine("{0} {1} is {2} local time.", 
                        hwTime, 
                        hwZone.IsDaylightSavingTime(hwTime) ? hwZone.DaylightName : hwZone.StandardName, 
                        TimeZoneInfo.ConvertTime(hwTime, hwZone, TimeZoneInfo.Local));
            }
            catch (TimeZoneNotFoundException)
            {
                Console.WriteLine("The registry does not define the Hawaiian Standard Time zone.");
            }                           
            catch (InvalidTimeZoneException)
            {
                Console.WriteLine("Registry data on the Hawaiian Standard Time zone has been corrupted.");
            }
        }   
    }
}

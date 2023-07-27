using System;
using System.Collections.Generic;
using System.IO; 

namespace CSVAnalyser
{
    class CSVAnalyser
    {
        static void Main(string[] args)  
        {  
            string[] parts = new string[1200];
            List<Row> sheetRows = new List<Row>();

            try
            {
                //Reading the file using BufferedStream
                using (FileStream fs = File.Open(@"/Users/mohanasowdesh/Documents/Copy Of Birth and Death Dataset.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs))
                {
                    string line;
                    line = sr.ReadLine();
                    while ((line = sr.ReadLine()) != null)
                    {
                        parts = line.Split(",");
                        sheetRows.Add(new Row(){Period = Convert.ToInt32(parts[0]), Birth_Death = parts[1], Region = parts[2], Count = Convert.ToUInt64(parts[3])});
                    }
                }

                while(true)
                {
                    //Printing the menu
                    System.Console.WriteLine("\nMenu: \n1. Display all the Regions as a List without Duplicates \n2. Display all the year mentioned under Period without Duplicates \n3. Find the overall Birth and Death count for all the years \n4. Calculate the Year wise Birth and Death \n5. Display the number of Birth and Death for all the years for a specific Region \n6. Find which year has highest Birth and Death Rate \n7. Display the highest Birth and Death Rate for each region along with the year");
                    System.Console.WriteLine("Please enter your choice: ");
                    string usrChoice = Console.ReadLine();
                
                    switch (usrChoice)
                    {
                        case "1":
                        {
                            HashSet<string> regionsSet = DisplayRegionsSet(sheetRows);
                            System.Console.WriteLine("\nDisplaying unique regions:");
                            foreach(string i in regionsSet)
                            {
                                System.Console.WriteLine(i);
                            }
                            break;
                        }
                        case "2":
                        {
                            DisplayYearsSet(sheetRows);
                            break;
                        }
                        case "3":
                        {
                            DisplayBirthAndDeathCount(sheetRows);
                            break;
                        }
                        case "4":
                        {
                            Dictionary<int, List<ulong>> birthAndDeathCount = DisplayBirthAndDeathCountForEachYear(sheetRows);
                            System.Console.WriteLine("\nPrinting birth and death count for each year:");
                            PrintDictionary(birthAndDeathCount);
                            break;
                        }
                        case "5":
                        {
                            DisplayBirthAndDeathCountForEachRegion(sheetRows);
                            break;
                        }
                        case "6":
                        {
                            FindHighestBirthAndDeathRate(sheetRows);
                            break;
                        }
                        case "7":
                        {
                            DisplayHighestBirthAndDeathCountForAYear(sheetRows);
                            break;
                        }
                        default:
                        {
                            System.Console.WriteLine("Please enter a valid choice!!");
                            break;
                        }
                    }
                }
            }  
            catch (Exception exp)  
            {  
                Console.WriteLine(exp.Message);  
            }  
        }

        //Method that pushes all regions from the list to HashSet
        public static HashSet<string> DisplayRegionsSet(List<Row> sheetRows)
        {
            HashSet<string> regionsSet = new HashSet<string>();
            foreach(Row row in sheetRows)
            {
                regionsSet.Add(row.Region);
            }
            return regionsSet;
        }

        //Method that pushes all years from the list to HashSet
        public static void DisplayYearsSet(List<Row> sheetRows)
        {
            HashSet<int> yearsSet = new HashSet<int>();
            foreach(Row row in sheetRows)
            {
                yearsSet.Add(row.Period);
            }
            System.Console.WriteLine("\nDisplaying unique years:");
            foreach(int i in yearsSet)
            {
                System.Console.WriteLine(i);
            }
        }

        //Method that counts all the birth and deaths along all the years
        public static void DisplayBirthAndDeathCount(List<Row> sheetRows)
        {
            ulong birthCount = 0;
            ulong deathCount = 0;
            foreach(Row row in sheetRows)
            {
                if(row.Birth_Death == "Births")
                    birthCount = birthCount + row.Count;
                else if(row.Birth_Death == "Deaths")
                    deathCount = deathCount + row.Count;
            }
            System.Console.WriteLine("\nOverall births from 2005 to 2021 is {0}", birthCount);
            System.Console.WriteLine("Overall deaths from 2005 to 2021 is {0}", deathCount);
        }

        //Method that calculates year wise birth and deaths
        public static Dictionary<int, List<ulong>> DisplayBirthAndDeathCountForEachYear(List<Row> sheetRows)
        {
            Dictionary<int, List<ulong>> birthAndDeathCount = new Dictionary<int, List<ulong>>();

            foreach(Row row in sheetRows)
            {
                ulong value = 0;
                if(!birthAndDeathCount.ContainsKey(row.Period))
                    birthAndDeathCount[row.Period] = new List<ulong>(){0,0};

                if(row.Birth_Death == "Births")
                    birthAndDeathCount[row.Period][0] += row.Count;
                else if(row.Birth_Death == "Deaths")
                    birthAndDeathCount[row.Period][1] += row.Count;
            }

            return birthAndDeathCount;
        }

        //Method that displays birth and death count for each region
        public static void DisplayBirthAndDeathCountForEachRegion(List<Row> sheetRows)
        {
            System.Console.WriteLine("\nPlease enter the region for which birth and death count needs to be calculated: ");
            string userInputRegion = Console.ReadLine();

            List<Row> region = sheetRows.FindAll(row => row.Region == userInputRegion);

            if(region.Count == 0)
            {
                System.Console.WriteLine("No such region found");
                return;
            }
            ulong birthCount = 0, deathCount = 0;
            foreach(Row row in region)
            {
                if(row.Birth_Death == "Births")
                    birthCount = birthCount + row.Count;
                else if(row.Birth_Death == "Deaths")
                    deathCount = deathCount + row.Count;
            }

            System.Console.WriteLine("\nBirth count in {0} is {1}", userInputRegion, birthCount);
            System.Console.WriteLine("Death count in {0} is {1}", userInputRegion, deathCount);
        }

        //Method to find which year has the highest birth and death count
        public static void FindHighestBirthAndDeathRate(List<Row> sheetRows)
        {
            Dictionary<int, List<ulong>> resultDictionary = DisplayBirthAndDeathCountForEachYear(sheetRows);
            int maxBirthYear = FindMaxValue(resultDictionary, 0);
            int maxDeathYear = FindMaxValue(resultDictionary, 1);
            
            System.Console.WriteLine("\nThe year with the highest birth count is {0}", maxBirthYear);
            System.Console.WriteLine("The year with the highest death count is {0}", maxDeathYear);
        }   

        //Method that displays the year which has the highest birth and death count for each region
        public static void DisplayHighestBirthAndDeathCountForAYear(List<Row> sheetRows)
        {
            HashSet<string> regionsSet = DisplayRegionsSet(sheetRows);
            foreach(string region in regionsSet)
            {
                var maxBirthYear = FilterAndSortRowsForEachRegion(sheetRows, region, "Births");
                var maxDeathYear = FilterAndSortRowsForEachRegion(sheetRows, region, "Deaths");
                
                System.Console.WriteLine("\nRegion: {0}, Period: {1}, Max birth count: {2}", region, maxBirthYear.Period, maxBirthYear.Count);
                System.Console.WriteLine("Region: {0}, Period: {1}, Max death count: {2}", region, maxDeathYear.Period, maxDeathYear.Count);
            }
        }

        //Method to filter and sort the rows for a specific region based on the given parameter
        public static Row FilterAndSortRowsForEachRegion(List<Row> sheetRows, string region, string parameter)
        {
            var specificRegionRow = sheetRows.FindAll(x => (x.Region == region && x.Birth_Death == parameter));
            var sortedElements = specificRegionRow.OrderBy(x => x.Count);
            return sortedElements.Last();
        }

        //Method to print the passed dictionary
        public static void PrintDictionary(Dictionary<int, List<ulong>> dictionary)
        {
            foreach (KeyValuePair<int, List<ulong>> keyValuePair in dictionary)
            {
                System.Console.WriteLine("{0} ---> No. of births: {1}, No. of deaths: {2}", keyValuePair.Key, keyValuePair.Value[0] , keyValuePair.Value[1]);
            }
        }

        //Method to find the year which has the maximum birth/death count by sorting the passed dictionary
        public static int FindMaxValue(Dictionary<int, List<ulong>> dictionary, int value)
        {
            var sortedElements = dictionary.OrderBy(kvp => kvp.Value[value]);
            return sortedElements.Last().Key;
        }
    }
}

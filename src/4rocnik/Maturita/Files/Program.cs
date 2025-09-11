using System;
using System.Collections.Generic;
using System.IO;
using Files.Properties;

namespace Files
{
    internal class Program
    {
        public static List<Movies> Movies = new List<Movies>();

        public static void Main(string[] args)
        {
            GetMovie("./movies.csv");
            foreach (var movie in Movies)
            {
                Console.WriteLine(movie); // ToString() will output the film name
            }
        }

        public static void WorstMovie()
        {
            foreach (var movie in Movies)
            {
            }
        }

        public static void GetMovie(string filePath)
        {
            // Open the CSV file and read it
            using (StreamReader csvReader = new StreamReader(filePath))
            {
                string line;
                csvReader.ReadLine();

                while ((line = csvReader.ReadLine()) != null)
                {
                    csvReader.ReadLine();
                    // Skip empty or whitespace-only lines
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    // Split the line into parts (assuming CSV format with commas)
                    var parts = line.Split(',');

                    // Ensure that the parts array contains the expected number of values (8 for your data)
                    if (parts.Length == 8)
                    {
                        // Create a new Movies object and add it to the list
                        Movies.Add(new Movies(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6],
                            parts[7]));
                    }
                    else
                    {
                        Console.WriteLine("Skipping malformed line: " + line);
                    }
                }
            }
        }
    }
}
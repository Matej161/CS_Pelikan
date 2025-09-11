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
            Console.WriteLine(Movies);
        }

        public static void GetMovie(string filePath)
        {
            using (StreamReader scvReader = new StreamReader(filePath))
            {
                string line;
                while ((line = scvReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                var parts = line.Split(',');
                
                Movies.Add(new Movies(parts[0], parts[1], parts[2], parts[3],  parts[4],  parts[5], parts[6]));
            }
        }
    }
}
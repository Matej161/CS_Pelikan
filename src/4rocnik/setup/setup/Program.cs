using System;

namespace setup
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GuessTheNum guessTheNum = new GuessTheNum(1, 5);
            for (int i = 0; i <= 100; i++)
            {
                FizzBuzz(i);
            }
        }

        public static void FizzBuzz(int num)
        {
            if (num % 3 == 0 && num % 5 == 0)
            {
                Console.WriteLine("fizzbuzz");
            }
            else if (num % 3 == 0)
            {
                Console.WriteLine("fizz");
                
            }
            else if (num % 5 == 0)
            {
                Console.WriteLine("buzz");
                
            }
            else
            {
                Console.WriteLine(num);
            }
        }
    }
}